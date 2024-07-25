using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    private PlayerHealth _playerHealth;
    private Rigidbody2D _rigidbody2d;
    private Vector2 move;
    private float _playerSpeed = 5.0f;
    void Start()
    {
        MoveAction.Enable();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
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
