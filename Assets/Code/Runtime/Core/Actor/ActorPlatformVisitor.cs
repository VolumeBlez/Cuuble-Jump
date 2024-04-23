using UnityEngine;

public class ActorPlatformVisitor : MonoBehaviour, IPlatformVisitor
{
    [SerializeField] private Actor _actor;

    public void Visit(IPlatform platform)
    {
        EventBus<ActorTouchPlatform>.Raise(new ActorTouchPlatform() { PlatformType = platform.Type});
        _actor.SetJump(platform.JumpForce);
    }
}
