using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private Transform _platformsParent;
    [SerializeField] private float _spawnWidth;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _startY;
    private Vector2 _position;

    private void Start()
    {
        _position.y = _startY;
        
        for (int i = 0; i < 100; i++)
        {
            _position.x = Random.Range(-_spawnWidth, _spawnWidth);
            _position.y += Random.Range(_minY, _maxY);
            Instantiate(_platformPrefab, _position, Quaternion.identity, _platformsParent);
        }
    }

}
