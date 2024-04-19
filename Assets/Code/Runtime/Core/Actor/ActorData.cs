using UnityEngine;

[CreateAssetMenu(fileName = "Actor Data")]
public class ActorData : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float JumpHeight { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; }
}
