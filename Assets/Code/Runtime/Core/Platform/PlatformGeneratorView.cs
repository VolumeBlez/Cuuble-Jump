using UnityEngine;

public class PlatformGeneratorView : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Transform _platformsParent;
    [SerializeField] private float _generationBorderDelta;
    [SerializeField] private float _offset;
    [SerializeField] private float _maxXSpread;
    [SerializeField] private float _minYSpread;
    [SerializeField] private float _maxYSpread;
    [SerializeField] private float _startY;
    
    private PlatformGenerator _generator;

    private void Start()
    {
        _generator = new PlatformGenerator(_minYSpread, _maxYSpread, _maxXSpread, _platformsParent, _platformPrefab);

        _generator.Generate(_startY, _startY + _generationBorderDelta);
        transform.position = new Vector3(0, transform.position.y + _generationBorderDelta - _offset, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Actor>() != null)
        {
            _generator.Generate(transform.position.y, transform.position.y + _generationBorderDelta);
            transform.position = new Vector3(0, transform.position.y + _generationBorderDelta - _offset, 0);
        }
    }
}
