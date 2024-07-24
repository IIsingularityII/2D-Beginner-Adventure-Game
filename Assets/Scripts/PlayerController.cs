using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private Rigidbody2D _rigidbody2d;
    private Vector2 move;
    private float _playerSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector2 position = (Vector2)_rigidbody2d.position + move * _playerSpeed * Time.deltaTime;
        _rigidbody2d.MovePosition(position);
    }
}
