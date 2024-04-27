using UnityEngine;

public class ActorPlatformVisitor : MonoBehaviour, IPlatformVisitor
{
    [SerializeField] private Actor _actor;

    public void Visit(IPlatform platform)
    {
        EventBus<ActorTouchPlatformEvent>.Raise(new ActorTouchPlatformEvent() { PlatformType = platform.Type, Ycoord = transform.position.y});
        _actor.SetJump(platform.JumpForce);
    }
}
