using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _rayPoint;

    private PlayerMovementController _movementController;

    private bool _isInteracting = false;

    private void Awake()
    {
        _movementController = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        _isInteracting = InteractWithObject();
    }

    private bool InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, Vector2.up, 20f);

        if (hit.collider == null)
            return false;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (interactable == null)
            return false;

        interactable.Interact();
        return true;
    }
}
