using UnityEngine;

public class MyProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private float _projectileLifeTime = 2.0f;
    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _projectileLifeTime -= Time.deltaTime;
        if(_projectileLifeTime < 0) Destroy(gameObject);
    }
    public void Launch(Vector2 direction, float force)
    {
        _rigidBody2D.AddForce(direction * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
        if (enemy != null) enemy.Fix();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyBehaviour enemy))
        {
            enemy.Fix();
            Destroy(gameObject);
        }
    }
}
