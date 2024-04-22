using UnityEngine;

public class ActorPlatformVisitor : MonoBehaviour, IPlatformVisitor
{
    [SerializeField] private Actor _actor;

    public void Visit(IPlatform platform)
    {
        _actor.SetJump(platform.JumpForce);
    }
}
