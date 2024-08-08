using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public ParticleSystem SmokeEffect;
    private Animator _animator;
    private Rigidbody2D _enemyRb;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private AudioClip _fixClip;
    [SerializeField] private float _changeTime = 3.0f;
    [SerializeField] private int _damageDeal = 2;
    private float _timer;
    private float _speed = 1.0f;
    private int _direction = 1;
    private bool _isVertical;
    private bool _isAgressive = true;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _timer = _changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            _timer = _changeTime;
            _isVertical = !_isVertical;
            if(_isVertical) 
            {
                _direction = -_direction;
                _animator.SetFloat("Move X", 0);
                _animator.SetFloat("Move Y", _direction);
            }
            else
            {
                _animator.SetFloat("Move X", _direction);
                _animator.SetFloat("Move Y", 0);
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (!_isAgressive) return;
        Vector2 position = _enemyRb.position;
        if (_isVertical)
        {
            position.y = position.y + _speed * _direction * Time.deltaTime;
        }
        else
        {
            position.x = position.x + _speed * _direction * Time.deltaTime;
        }
        _enemyRb.MovePosition(position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damageDeal);
        }
    }
    public void Fix()
    {
        _audioSource.PlayOneShot(_hitClip);
        _audioSource.Stop();
        _isAgressive = false;
        _enemyRb.simulated = false;
        _animator.SetTrigger("Fixed");
        _audioSource.PlayOneShot(_fixClip);
        SmokeEffect.Stop();
    }
}
