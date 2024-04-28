using UnityEngine;

public class ActorPlatformVisitor : MonoBehaviour, IPlatformVisitor
{
    [SerializeField] private Actor _actor;

    public void Visit(IPlatform platform)
    {
        _actor.SetJump(platform.JumpForce);
        EventBus<ActorTouchPlatformEvent>.Raise(new ActorTouchPlatformEvent() { PlatformType = platform.Type, Ycoord = transform.position.y});
    }
}
