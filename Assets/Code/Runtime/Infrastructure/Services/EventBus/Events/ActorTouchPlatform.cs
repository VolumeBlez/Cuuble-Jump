using System;

public struct ActorTouchPlatform : IEvent
{
    public Type PlatformType { get; set; }
}