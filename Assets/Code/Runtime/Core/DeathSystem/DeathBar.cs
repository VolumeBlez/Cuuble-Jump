using UnityEngine;

public class DeathBar : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.y > 0f)
            return;

        if(other.transform.GetComponent<Platform>() != null)
        {
            other.gameObject.SetActive(false);
        }
        else if(other.transform.GetComponent<Actor>() != null)
        {
            EventBus<ActorDieEvent>.Raise(new ActorDieEvent());
        }
    }
}
