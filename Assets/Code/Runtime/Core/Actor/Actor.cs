using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private InputHandler _handler;
    [SerializeField] private ActorData _data;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _levelWidth;

    private Vector2 _currentMoveDirection;
    private Vector2 _newMoveDirection;

    private void Start()
    {
        _rb.gravityScale = _data.Gravity;
        _handler.InputMoveDirectionChanged += OnInputMoveDirectionChanged;
    }

    private void OnInputMoveDirectionChanged(Vector3 inputDirection)
    {
        if(_newMoveDirection.x != inputDirection.x)
        {
            _newMoveDirection.x = inputDirection.x;
        }
    }

    private void Update() 
    {
        SetActorInScreen();
        SetCurrentMoveDirection();
    }

    private void FixedUpdate()
    {
        SetCurrentMoveDirection();
    }

    private void SetCurrentMoveDirection()
    {
        _currentMoveDirection.x = _newMoveDirection.x * _data.MoveSpeed * Time.deltaTime;
        _currentMoveDirection.y = _rb.velocity.y;
        _rb.velocity = _currentMoveDirection;
    }

    public void SetJump(float jumpForce)
    {        
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }

    private void SetActorInScreen()
    {
        if(transform.position.x > _levelWidth)
            transform.position -= new Vector3(_levelWidth * 2, 0, 0);
        
        else if(transform.position.x < -_levelWidth)
            transform.position += new Vector3(_levelWidth * 2, 0, 0);
        
    }
}
