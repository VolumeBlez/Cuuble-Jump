using UnityEngine;

public class DeathBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Platform>() != null)
        {
            // despawn platform in pool
        }
        else if(other.GetComponent<Actor>() != null)
        {
            // call death of actor
        }
    }
}
