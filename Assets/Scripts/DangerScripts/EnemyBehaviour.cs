using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] private float _changeTime = 3.0f;
    [SerializeField] private int _damageDeal = 2;
    private float _timer;
    private float _speed = 1.0f;
    private int _direction = 1;
    private bool _isVertical;
    // Start is called before the first frame update
    void Start()
    {
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
            _isVertical = (_direction > 0 || _direction < 0) && !_isVertical;
            if (_isVertical) _direction = -_direction;
        }
    }
    private void FixedUpdate()
    {
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
}
