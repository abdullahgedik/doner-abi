using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _rayPoint;

    private bool _isInteracting = false;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            InteractWithObject();

        if (Input.GetKeyDown(KeyCode.F))
            PickUpFoodObject();

        if (Input.GetKeyDown(KeyCode.G))
            DropFoodObject();
    }

    private void InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, Vector2.up, 20f);

        if (hit.collider == null)
            return;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (interactable == null)
            return;

        interactable.Interact();
        return;
    }

    private void PickUpFoodObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, Vector2.up, 20f);

        if (hit.collider == null)
            return;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (interactable == null)
            return;

        interactable.PickUp();
        return;
    }

    private void DropFoodObject()
    {
        
    }
}
