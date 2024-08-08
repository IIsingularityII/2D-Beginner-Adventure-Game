using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction LaunchAction;
    public InputAction TalkAction;
    [SerializeField] private GameObject projectilePrefab;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _launchClip;
    private Animator _animator;
    private Rigidbody2D _rigidbody2d;
    private Vector2 _move;
    private Vector2 _moveDirection = new Vector2(1, 0);
    private float _playerSpeed = 5.0f;
    private float _rayLength = 1.5f;
    void Start()
    {
        MoveAction.Enable();
        LaunchAction.Enable();
        TalkAction.Enable();
        TalkAction.performed += FindFriend;
        LaunchAction.performed += Launch;
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
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
    private void Launch(InputAction.CallbackContext context)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, _rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        MyProjectile projectile = projectileObject.GetComponent<MyProjectile>();
        projectile.Launch(_moveDirection, 300);
        _audioSource.PlayOneShot(_launchClip);
        _animator.SetTrigger("Launch");
    }
    private void FindFriend(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2d.position + Vector2.up * 0.2f, _moveDirection, _rayLength, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            MyNonPlayerCharacter character = hit.collider.GetComponent<MyNonPlayerCharacter>();
            if (character != null) MyUIHandler.instance.DisplayDialogue();
        }
    }
  
}
