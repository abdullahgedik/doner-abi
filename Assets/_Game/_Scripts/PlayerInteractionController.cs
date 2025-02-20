using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private Transform _carryPoint;

    private ProducedFood _carriedObject;

    private void Awake()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            InteractWithObject();
        else if (Input.GetKeyDown(KeyCode.F))
            PickUpFoodObject();
        else if (Input.GetKeyDown(KeyCode.G))
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

    // private void PickUpFoodObject()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, Vector2.up, 20f);

    //     if (hit.collider == null)
    //         return;

    //     IInteractable interactable = hit.collider.GetComponent<IInteractable>();

    //     if (interactable == null)
    //         return;

    //     interactable.PickUp();
    //     return;
    // }

    private void PickUpFoodObject()
    {
        var collider = Physics2D.OverlapCircle(transform.position, 1.5f);

        if (collider.TryGetComponent(out ProducedFood producedFood))
        {
            _carriedObject = producedFood;
            _carriedObject.transform.SetParent(_carryPoint);
            _carriedObject.transform.localPosition = Vector3.zero;
            _carriedObject.SetKinematic(true);
        }
    }

    private void DropFoodObject()
    {

    }
}
