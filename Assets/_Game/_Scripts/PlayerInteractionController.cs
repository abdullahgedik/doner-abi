using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        InteractWithObject();
    }

    private void InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10f);

        if (hit.collider == null)
            return;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if (interactable == null)
            return;

        interactable.Interact();
    }
}
