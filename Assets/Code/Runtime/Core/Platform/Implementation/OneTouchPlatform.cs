public class OneTouchPlatform : Platform
{
    public override void Accept(IPlatformVisitor visitor)
    {
        base.Accept(visitor);
        gameObject.SetActive(false);
    }
}
