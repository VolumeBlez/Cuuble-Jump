using UnityEngine;

public class DeathBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Platform>() != null)
        {
            other.gameObject.SetActive(false);
        }
        else if(other.GetComponent<Actor>() != null)
        {
            // call death of actor
        }
    }
}
