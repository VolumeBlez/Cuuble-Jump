using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.y <= 0f)
        {
            if(other.transform.TryGetComponent(out Actor actor))
            {
                actor.SetJump(_jumpForce);
            }
        }
    }
}
