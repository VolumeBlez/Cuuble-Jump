using UnityEngine;

[CreateAssetMenu(fileName = "Level Data")]
public class LevelData : ScriptableObject
{
    [field: SerializeField] public float Gravity { get; private set; }
    [field: SerializeField] public float LevelWidth { get; private set; }
}
