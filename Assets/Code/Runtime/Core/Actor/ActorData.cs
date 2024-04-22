using UnityEngine;

[CreateAssetMenu(fileName = "Actor Data")]
public class ActorData : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
}
