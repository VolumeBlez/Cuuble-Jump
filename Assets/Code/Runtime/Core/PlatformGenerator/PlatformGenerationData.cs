using System;
using UnityEngine;

[Serializable]
public class PlatformGenerationType
{
    public Platform Prefab;
    public float Chance;
    public int PoolCount;
}

[CreateAssetMenu(fileName = "Platform Generation Data")]
public class PlatformGenerationData : ScriptableObject
{
    [field: SerializeField] public Platform PlatfromPrefab { get; private set; }
    [field: SerializeField] public float MaxXSpread { get; private set; }
    [field: SerializeField] public float MaxYSpread { get; private set; }
    [field: SerializeField] public float MinYSpread { get; private set; }
    [field: SerializeField] public float GenerationBorderStep { get; private set; }
    [field: SerializeField] public float BorderOffset { get; private set; }
    [field: SerializeField] public int PlatformsMaxCountOnStep { get; private set; }
    [field: SerializeField] public float GenerationStartY { get; private set; }
    [field: SerializeField] public PlatformGenerationType[] PlatformTypes { get; private set; }
}
