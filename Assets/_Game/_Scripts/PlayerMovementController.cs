using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector3 _movement;

    private bool _isMovementEnabled = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        if (!_isMovementEnabled)
            return;

        Move();
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _movement * _movementSpeed * Time.fixedDeltaTime);
    }

    public void ToggleMovement(bool value)
    {
        _isMovementEnabled = value;
    }
}
