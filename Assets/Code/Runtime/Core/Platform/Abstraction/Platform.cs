using System;
using UnityEngine;

public abstract class Platform : MonoBehaviour, IPlatform
{
    [SerializeField] private float _jumpForce;

    public float JumpForce => _jumpForce;
    public Type Type => GetType();

    public virtual void Accept(IPlatformVisitor visitor)
    {
        visitor.Visit(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.y <= 0f)
        {
            if(other.transform.TryGetComponent(out IPlatformVisitor visitor))
            {
                Accept(visitor);
            }
        }
    }    
}
