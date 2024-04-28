using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlobalAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    [Header("Platform Sounds")]
    [SerializeField] private AudioClip _oneTouchPlatformSound;
    [SerializeField] private AudioClip _defaultPlatformSound;
    [SerializeField] private AudioClip _boostPlatformSound;

    [Header("Actor Die Sound")]
    [SerializeField] private AudioClip _actorDeathSound;

    private EventBinding<ActorTouchPlatformEvent> _actorTouchPlatformEventHandler;
    private EventBinding<ActorDieEvent> _actorDieEventHandler;
    private Type _oneTouchPlatformType = typeof(OneTouchPlatform);
    private Type _boostPlatformType = typeof(JumpBoostPlatform);

    private void OnEnable()
    {
        _actorTouchPlatformEventHandler = new EventBinding<ActorTouchPlatformEvent>(OnActorTouchedPlatformEventHandle);
        EventBus<ActorTouchPlatformEvent>.Register(_actorTouchPlatformEventHandler);    

        _actorDieEventHandler = new EventBinding<ActorDieEvent>(OnActorDieEventHandle);
        EventBus<ActorDieEvent>.Register(_actorDieEventHandler); 
    }

    private void OnDisable()
    {
        EventBus<ActorTouchPlatformEvent>.Unregister(_actorTouchPlatformEventHandler);
        EventBus<ActorDieEvent>.Unregister(_actorDieEventHandler);
    }

    private void OnActorTouchedPlatformEventHandle(ActorTouchPlatformEvent actorTouchPlatform)
    {
        _source.pitch = Random.Range(0.8f, 1.2f);

        if(actorTouchPlatform.PlatformType == _oneTouchPlatformType)
        {
            _source.PlayOneShot(_oneTouchPlatformSound);
        }
        else if(actorTouchPlatform.PlatformType == _boostPlatformType)
        {
            _source.PlayOneShot(_boostPlatformSound);
        }
        else
        {
            _source.PlayOneShot(_defaultPlatformSound);
        }
    }

    private void OnActorDieEventHandle()
    {
        _source.pitch = Random.Range(0.8f, 1.2f);
        _source.PlayOneShot(_actorDeathSound);
    }

}
