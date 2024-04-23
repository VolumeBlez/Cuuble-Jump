using UnityEngine;

public class ActorDeathHandler : MonoBehaviour
{
    private EventBinding<ActorDieEvent> _actorDieEventBinding;

    private void OnEnable()
    {
        _actorDieEventBinding = new EventBinding<ActorDieEvent>(OnActorDie);
        EventBus<ActorDieEvent>.Register(_actorDieEventBinding);    
    }

    private void OnDisable()
    {
        EventBus<ActorDieEvent>.Unregister(_actorDieEventBinding);
    }

    private void OnActorDie()
    {
        Debug.Log("Actor Died");
    }
}
