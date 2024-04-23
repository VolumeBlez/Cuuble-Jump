using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _alphaObject;
    [SerializeField] private Button _button;
    [SerializeField, Range(0.005f, 0.07f)] private float _fadeInSpeed;
    
    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void SetClickAction(Action action)
    {
        _button.onClick.AddListener(() => action.Invoke());
    }

	public void Hide(float fadeInSpeed = default)
    {
        if(fadeInSpeed == default)
            fadeInSpeed = _fadeInSpeed;

        StartCoroutine(DoFadeIn(() => _button.gameObject.SetActive(false), fadeInSpeed));
    }

    public void Destroy(float fadeInSpeed = default)
    {
        if(fadeInSpeed == default)
            fadeInSpeed = _fadeInSpeed;

        StartCoroutine(DoFadeIn(() => Destroy(gameObject), fadeInSpeed));
    }

    public void Show()
    {
        _button.gameObject.SetActive(true);
        _alphaObject.alpha = 1;
    }

    private IEnumerator DoFadeIn(Action actionAfterFadeIn, float fadeInSpeed)
	{
        while (_alphaObject.alpha > 0)
        {
            _alphaObject.alpha -= 0.03f;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        
        actionAfterFadeIn.Invoke();
	}
}
