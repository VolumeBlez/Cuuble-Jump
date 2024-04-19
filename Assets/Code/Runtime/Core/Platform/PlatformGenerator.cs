using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator
{
    private Transform _platformParent;
    private List<Platform> _platforms;
    private float _maxXSpred;
    private float _minYSpread;
    private float _maxYSpread;

    public PlatformGenerator(float minYSpread, float maxYSpread, float maxXSpred, Transform platformParent, Platform prefab)
    {
        _minYSpread = minYSpread;
        _maxYSpread = maxYSpread;
        _maxXSpred = maxXSpred;
        _platformParent = platformParent;

        _platforms = new(40);

        for (int i = 0; i < 40; i++)
        {
            Platform platform = GameObject.Instantiate(prefab, Vector2.zero, Quaternion.identity, _platformParent);
            _platforms.Add(platform);
        }
    }

    public void Generate(float firstY, float generatorBorder)
    {
        Vector2 position;
        position.x = Random.Range(-_maxXSpred, _maxXSpred);
        position.y = firstY;

        _platforms[0].transform.position = position;

        for (int i = 1; i < _platforms.Count; i++)
        {
            position.y += Random.Range(_minYSpread, _maxYSpread);

            if(position.y >= generatorBorder)
                break;

            position.x = Random.Range(-_maxXSpred, _maxXSpred);
            _platforms[i].transform.position = position;
        }
    }

}
