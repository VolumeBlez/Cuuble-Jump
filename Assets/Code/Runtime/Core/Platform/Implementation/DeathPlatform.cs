public class DeathPlatform : Platform
{
    public override void Accept(IPlatformVisitor visitor)
    {
        base.Accept(visitor);
        EventBus<ActorDieEvent>.Raise(new ActorDieEvent());
        Destroy(gameObject);
    }
}
