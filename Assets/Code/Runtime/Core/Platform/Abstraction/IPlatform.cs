using System;

public interface IPlatform
{
    Type Type { get; }
    float JumpForce { get; }
    void Accept(IPlatformVisitor visitor);
}
