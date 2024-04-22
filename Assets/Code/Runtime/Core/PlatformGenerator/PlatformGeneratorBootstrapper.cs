using UnityEngine;

public class PlatformGeneratorBootstrapper : MonoBehaviour
{
    [SerializeField] private PlatformGenerationData _data;
    [SerializeField] private PlatformGeneratorView _view;
    
    public void Init()
    {
        PlatformPool platformPool = new(_data.PlatfromPrefab, transform, _data.PlatformsMaxCountOnStep);
        PlatformGenerator generator = new PlatformGenerator(_data, platformPool);

        generator.Generate(_data.GenerationStartY);

        _view.transform.position = new Vector3(0, _data.GenerationStartY + _data.GenerationBorderStep - _data.BorderOffset, 0);
        _view.Init(generator, _data.GenerationBorderStep, _data.BorderOffset);
    }
}
