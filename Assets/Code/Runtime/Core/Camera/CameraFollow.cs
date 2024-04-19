using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;
    private Transform _selfTransform;
    private Vector3 _velocity;
    private Vector3 _newPos;

    void Start()
    {
        _selfTransform  = transform;
        _newPos = new Vector3(_selfTransform.position.x, _target.position.y , _selfTransform.position.z);
    }

    void LateUpdate()
    {
        if(_selfTransform.position.y < _target.position.y)
        {
            _newPos.y = _target.position.y;
            _selfTransform.position = Vector3.SmoothDamp(_selfTransform.position, _newPos, ref _velocity, _followSpeed * Time.deltaTime);
        }
    }
}
