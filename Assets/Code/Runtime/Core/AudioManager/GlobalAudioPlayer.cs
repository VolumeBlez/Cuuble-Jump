using System;
using UnityEngine;

public class GlobalAudioPlayer : MonoBehaviour
{
    // [SerializeField] private AudioSource _source;
    // [SerializeField] private AudioClip _oneTouchPlatformSound;
    // [SerializeField] private AudioClip _defaultPlatformSound;

    // private EventBinding<ActorTouchPlatformEvent> _actorTouchPlatformEvent;
    // private Type _oneTouchPlatformType = typeof(OneTouchPlatform);
    // private Type _defaultPlatformType = typeof(DefaultPlatform);

    // private void OnEnable()
    // {
    //     _actorTouchPlatformEvent = new EventBinding<ActorTouchPlatformEvent>(OnActorTouchedPlatform);
    //     EventBus<ActorTouchPlatformEvent>.Register(_actorTouchPlatformEvent);    
    // }

    // private void OnDisable()
    // {
    //     EventBus<ActorTouchPlatformEvent>.Unregister(_actorTouchPlatformEvent);
    // }

    // private void OnActorTouchedPlatform(ActorTouchPlatformEvent actorTouchPlatform)
    // {
    //     if(actorTouchPlatform.PlatformType == _oneTouchPlatformType)
    //     {
    //         _source.PlayOneShot(_oneTouchPlatformSound);
    //     }
    //     else if(actorTouchPlatform.PlatformType == _defaultPlatformType)
    //     {
    //         _source.PlayOneShot(_defaultPlatformSound);
    //     }
    // }

}
