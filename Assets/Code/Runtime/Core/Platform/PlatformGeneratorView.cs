using UnityEngine;

public class PlatformGeneratorView : MonoBehaviour
{
    private PlatformGenerator _generator;
    private float _borderStepY;
    private float _offset;

    public void Init(PlatformGenerator generator, float borderStepY, float offset)
    {
        _generator = generator;
        _borderStepY = borderStepY;
        _offset = offset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Actor>() != null)
        {
            _generator.Generate(transform.position.y + _offset);
            transform.position = new Vector3(0, transform.position.y + _borderStepY, 0);
        }
    }
}
