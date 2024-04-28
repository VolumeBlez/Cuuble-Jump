using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private ActorData _data;
    [SerializeField] private Rigidbody2D _rb;

    private InputHandler _handler;
    private Vector2 _currentMoveDirection;
    private Vector2 _inputMoveDirection;
    private float _levelWidth;

    public void Init(float levelGravity, float levelWidth, InputHandler handler)
    {
        _rb.gravityScale = levelGravity;
        _levelWidth = levelWidth;
        _handler = handler;

        _handler.InputMoveDirectionChanged += OnInputMoveDirectionChanged;
    }

    private void OnDestroy()
    {
        _handler.InputMoveDirectionChanged -= OnInputMoveDirectionChanged;
    }

    private void Update() 
    {
        SetActorInScreen();
        SetCurrentMoveDirection();
    }

    private void FixedUpdate()
    {
        //_rb.velocity = _currentMoveDirection;
        _rb.velocity = new Vector2(_currentMoveDirection.x, _rb.velocity.y);
    }

    private void SetCurrentMoveDirection()
    {
        _currentMoveDirection.x = _inputMoveDirection.x * _data.MoveSpeed * Time.deltaTime;
        //_currentMoveDirection.y = _rb.velocity.y;
    }

    private void SetActorInScreen()
    {
        if(transform.position.x > _levelWidth)
            transform.position -= new Vector3(_levelWidth * 2, 0, 0);
        
        else if(transform.position.x < -_levelWidth)
            transform.position += new Vector3(_levelWidth * 2, 0, 0);
        
    }

    private void OnInputMoveDirectionChanged(Vector3 inputDirection)
    {
        if(_inputMoveDirection.x != inputDirection.x)
        {
            _inputMoveDirection.x = inputDirection.x;
        }
    }

    public void SetJump(float jumpForce)
    {        
        //_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

        //_currentMoveDirection.y = jumpForce;

        //if(_rb.velocity.y <= 0)
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        
    }
}
