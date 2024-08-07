using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private Rigidbody2D _rigidbody2d;
    private Vector2 _move;
    private Vector2 _moveDirection = new Vector2(1, 0);
    private float _playerSpeed = 5.0f;
    void Start()
    {
        MoveAction.Enable();
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
    void Update()
    {
        _move = MoveAction.ReadValue<Vector2>();
        if (!Mathf.Approximately(_move.x, 0.0f) || !Mathf.Approximately(_move.y, 0.0f))
        {
            _moveDirection.Set(_move.x, _move.y);
            _moveDirection.Normalize();
        }
        _animator.SetFloat("Look X", _moveDirection.x);
        _animator.SetFloat("Look Y", _moveDirection.y);
        _animator.SetFloat("Speed", _move.magnitude);
    }
    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2d.position + _move * _playerSpeed * Time.deltaTime;
        _rigidbody2d.MovePosition(position);
    }
}
