using System;

public struct ActorTouchPlatformEvent : IEvent
{
    public Type PlatformType { get; set; }
    public float Ycoord { get; set; }
}
