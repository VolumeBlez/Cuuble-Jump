using System;
using UnityEngine;

public class GlobalAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _oneTouchPlatformSound;
    [SerializeField] private AudioClip _defaultPlatformSound;

    private EventBinding<ActorTouchPlatform> _actorTouchPlatformEvent;
    private Type _oneTouchPlatformType = typeof(OneTouchPlatform);
    private Type _defaultPlatformType = typeof(DefaultPlatform);

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
        Debug.Log(actorTouchPlatform.PlatformType.Name);

        if(actorTouchPlatform.PlatformType == _oneTouchPlatformType)
        {
            _source.PlayOneShot(_oneTouchPlatformSound);
        }
        else if(actorTouchPlatform.PlatformType == _defaultPlatformType)
        {
            _source.PlayOneShot(_defaultPlatformSound);
        }
    }

}
