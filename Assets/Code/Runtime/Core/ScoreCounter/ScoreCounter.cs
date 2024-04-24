using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textUI;
    private float _score;
    private EventBinding<ActorTouchPlatform> _actorTouchPlatformEvent;

    private void OnEnable()
    {
        _actorTouchPlatformEvent = new EventBinding<ActorTouchPlatform>(OnActorTouchedPlatform);
        EventBus<ActorTouchPlatform>.Register(_actorTouchPlatformEvent);    
    }

    private void OnDisable()
    {
        EventBus<ActorTouchPlatform>.Unregister(_actorTouchPlatformEvent);
    }

    private void OnActorTouchedPlatform(ActorTouchPlatform actorTouchPlatform)
    {
        if(actorTouchPlatform.Ycoord > _score)
        {
            _score = actorTouchPlatform.Ycoord;
            _textUI.text = "Score: " + (int)_score;
        }
    }
}
