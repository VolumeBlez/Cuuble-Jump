public interface IPlatform
{
    float JumpForce { get; }
    void Accept(IPlatformVisitor visitor);
}
