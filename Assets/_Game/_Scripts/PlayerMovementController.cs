using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 5f;

    [Header("References")]
    [SerializeField] private Renderer _renderer;

    private Rigidbody2D _rb;
    private Vector3 _movementVector;

    private bool _isMovementEnabled = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        if (!_isMovementEnabled)
            return;

        Move();

        HandleLeanAnimation();
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _movementVector * _movementSpeed * Time.fixedDeltaTime);
    }

    public void ToggleMovement(bool value)
    {
        if (value == _isMovementEnabled)
            return;

        _isMovementEnabled = value;

        if (!value)
            StopMoveAnimation();
    }

    private void HandleLeanAnimation()
    {
        if (_movementVector.magnitude > 0)
        {
            PlayMoveAnimation();
        }
        else
        {
            StopMoveAnimation();
        }
    }

    private void PlayMoveAnimation()
    {
        _renderer.transform.DOKill();
        _renderer.transform.DORotate(new Vector3(0, 0, 5 * PlayerDirection), 0.1f, RotateMode.Fast);
    }

    private void StopMoveAnimation()
    {
        _renderer.transform.DOKill();
        _renderer.transform.DORotate(Vector3.zero, 0.1f, RotateMode.Fast);
    }

    private float PlayerDirection => _movementVector.x > 0 ? 1 : -1;
}
