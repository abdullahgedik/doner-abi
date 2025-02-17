using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementController _movementController;
    private PlayerInteractionController _interactionController;
    private Rigidbody2D _rb;
    private Collider2D _collider;

    void Awake()
    {
        _movementController = GetComponent<PlayerMovementController>();
        _interactionController = GetComponent<PlayerInteractionController>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        _movementController.ToggleMovement(true);
    }
}
