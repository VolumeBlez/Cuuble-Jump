using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PlatformGenerationType
{
    public Platform Prefab;
    public float Lane;
}


public class PlatformGenerator
{
    private readonly PlatformPool _pool;
    private readonly PlatformGenerationData _data;

    public PlatformGenerator(PlatformGenerationData data, PlatformPool pool)
    {
        _pool = pool;
        _data = data;
    }

    public void Generate(float firstY)
    {
        Vector2 position;
        position.x = Random.Range(-_data.MaxXSpread, _data.MaxXSpread);
        position.y = firstY;

        SetUpPlatform(position);

        for (int i = 1; i < _data.PlatformsMaxCountOnStep; i++)
        {
            position.y += Random.Range(_data.MinYSpread, _data.MaxYSpread);

            if(position.y >= + _data.GenerationBorderStep + firstY)
                break;

            position.x = Random.Range(-_data.MaxXSpread, _data.MaxXSpread);
            SetUpPlatform(position);
        }
    }

    private void SetUpPlatform(Vector2 position)
    {
        Platform platform = _pool.GetPool();
        platform.transform.position = position;
        platform.gameObject.SetActive(true);
    }

}
