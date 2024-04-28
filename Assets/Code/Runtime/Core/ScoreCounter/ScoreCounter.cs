using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textUI;
    private float _score;
    private EventBinding<ActorTouchPlatformEvent> _actorTouchPlatformEvent;

    private void OnEnable()
    {
        _actorTouchPlatformEvent = new EventBinding<ActorTouchPlatformEvent>(OnActorTouchedPlatform);
        EventBus<ActorTouchPlatformEvent>.Register(_actorTouchPlatformEvent);    
    }

    private void OnDisable()
    {
        EventBus<ActorTouchPlatformEvent>.Unregister(_actorTouchPlatformEvent);
    }

    private void OnActorTouchedPlatform(ActorTouchPlatformEvent actorTouchPlatform)
    {
        if(actorTouchPlatform.Ycoord > _score)
        {
            _score = actorTouchPlatform.Ycoord;
            _textUI.text = "Score: " + (int)_score;
        }
    }
}
