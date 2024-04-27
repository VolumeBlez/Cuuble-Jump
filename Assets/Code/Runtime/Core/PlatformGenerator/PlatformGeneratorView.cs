using UnityEngine;

public class PlatformGeneratorView : MonoBehaviour
{
    private EventBinding<ActorTouchPlatformEvent> _actorTouchPlatformBinding;
    private PlatformGenerator _generator;
    private float _borderStepY;
    private float _offset;
    private float _currentBorder;

    public void Init(PlatformGenerator generator, float borderStepY, float offset, float startYcord)
    {
        _generator = generator;
        _borderStepY = borderStepY;
        _offset = offset;

        _generator.Generate(startYcord + _offset);
        _currentBorder = startYcord + _borderStepY;

        _actorTouchPlatformBinding = new EventBinding<ActorTouchPlatformEvent>(OnActorTouchPlatform);
        EventBus<ActorTouchPlatformEvent>.Register(_actorTouchPlatformBinding);
    }

    private void OnDisable()
        => EventBus<ActorTouchPlatformEvent>.Unregister(_actorTouchPlatformBinding);
    

    private void OnActorTouchPlatform(ActorTouchPlatformEvent actorTouchPlatformEvent)
    {
        if(actorTouchPlatformEvent.Ycoord >= _currentBorder)
        {
            _generator.Generate(_currentBorder + _offset);
            _currentBorder = _currentBorder + _borderStepY;
        }
    }
}
