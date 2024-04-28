using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorBootstrapper : MonoBehaviour
{
    [SerializeField] private PlatformGenerationData _data;
    [SerializeField] private PlatformGeneratorView _view;
    
    public void Init()
    {
        List<PlatformPool> _platformPools = new(_data.PlatformTypes.Length);

        foreach (PlatformGenerationType platformInfo in _data.PlatformTypes)
        {
            _platformPools.Add(new PlatformPool(platformInfo.Prefab, transform, platformInfo.PoolCount));
        }

       PlatformGenerator generator = new PlatformGenerator(_data, _platformPools);

        _view.Init(generator, _data.GenerationBorderStep, _data.BorderOffset, _data.GenerationStartY);
    }
}
