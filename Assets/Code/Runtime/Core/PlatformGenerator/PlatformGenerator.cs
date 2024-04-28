using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformGenerator
{
    private readonly PlatformPool _pool;
    private readonly PlatformGenerationData _data;
    private Vector2 _currentPlatformPosition;

    private List<PlatformPool> _platformPools;

    public PlatformGenerator(PlatformGenerationData data, PlatformPool pool)
    {
        _pool = pool;
        _data = data;

        _currentPlatformPosition.y = _data.GenerationStartY;
    }

    public PlatformGenerator(PlatformGenerationData data, List<PlatformPool> platformPools)
    {
        _data = data;
        _platformPools = platformPools;
    
        _currentPlatformPosition.y = _data.GenerationStartY;
    }

    public void Generate(float lowBorder)
    {
        _currentPlatformPosition.x = Random.Range(-_data.MaxXSpread, _data.MaxXSpread);

        SetUpPlatform(_currentPlatformPosition);

        for (int i = 1; i < _data.PlatformsMaxCountOnStep; i++)
        {
            _currentPlatformPosition.y += Random.Range(_data.MinYSpread, _data.MaxYSpread);

            if(_currentPlatformPosition.y >= + _data.GenerationBorderStep + lowBorder)
                break;

            _currentPlatformPosition.x = Random.Range(-_data.MaxXSpread, _data.MaxXSpread);
            SetUpPlatform(_currentPlatformPosition);
        }
    }

    // private void SetUpPlatform(Vector2 position)
    // {
    //     Platform platform = _pool.GetPool();
    //     platform.transform.position = position;
    //     platform.gameObject.SetActive(true);
    // }

    private void SetUpPlatform(Vector2 position)
    {
        List<float> chances = new List<float>();
        Type platformType = null;
        Platform platform = null;

        for (int i = 0; i < _data.PlatformTypes.Length; i++)
        {
            chances.Add(_data.PlatformTypes[i].Chance);
        }

        float currentChance = Random.Range(0, chances.Sum());
        float sum = 0;


        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if(currentChance < sum)
            {
                platformType = _data.PlatformTypes[i].Prefab.Type;
                break;
            }
        }

        foreach (var pool in _platformPools)
        {
            if(pool.PlatformType == platformType)
            {
                platform = pool.GetPool();
            }
        }
        
        platform.transform.position = position;
        platform.gameObject.SetActive(true);
    }

}
