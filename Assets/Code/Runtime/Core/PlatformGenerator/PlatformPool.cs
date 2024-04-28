using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool
{
    private List<Platform> _platforms;

    public Type PlatformType { get; }
    
    public PlatformPool(Platform prefabToPool, Transform parent, int poolSize)
    {
        _platforms = new(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            Platform platfrom = GameObject.Instantiate(prefabToPool, Vector2.zero, Quaternion.identity, parent);
            platfrom.gameObject.SetActive(false);
            _platforms.Add(platfrom);
        }
        
        PlatformType = prefabToPool.GetType();
    }

    public Platform GetPool()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            if(!_platforms[i].isActiveAndEnabled)
            {
                return _platforms[i];
            }
        }

        throw new ArgumentOutOfRangeException($"pool is out!");
    }
}
