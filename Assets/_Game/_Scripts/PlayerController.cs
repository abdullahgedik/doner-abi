using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private PlayerMovementController _movementController;
    private PlayerInteractionController _interactionController;
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private ProducedFood _carriedObject;
    private Transform _carryPoint;

    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float throwDuration = 0.5f;

    void Awake()
    {
        _movementController = GetComponent<PlayerMovementController>();
        _interactionController = GetComponent<PlayerInteractionController>();
        
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        _carryPoint = new GameObject("CarryPoint").transform;
        _carryPoint.SetParent(transform);
        _carryPoint.localPosition = new Vector3(1, 2, 0);
    }

    void Start()
    {
        _movementController.ToggleMovement(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_carriedObject != null)
            {
                ThrowObject();
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (_carriedObject != null)
            {
                DropObject();
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (_carriedObject == null)
            {
                TryPickUpObject();
            }
        }
    }

    private void TryPickUpObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (var collider in colliders)
        {
            ProducedFood producedFood = collider.GetComponent<ProducedFood>();
            if (producedFood != null)
            {
                _carriedObject = producedFood;
                _carriedObject.transform.SetParent(_carryPoint);
                _carriedObject.transform.localPosition = Vector3.zero;
                _carriedObject.SetKinematic(true);
                break;
            }
        }
    }

    private void DropObject()
    {
        if (_carriedObject != null)
        {
            _carriedObject.transform.SetParent(null);
            _carriedObject.SetKinematic(false);
            _carriedObject = null;
        }
    }

    private void ThrowObject()
    {
        if (_carriedObject != null)
        {
            _carriedObject.transform.SetParent(null);
            _carriedObject.SetKinematic(false);

            Vector2 throwDirection = transform.right * throwForce;
            _carriedObject.GetComponent<Rigidbody2D>().DOJump((Vector2)_carriedObject.transform.position + throwDirection, 2f, 1, throwDuration)
                .SetEase(Ease.OutQuad);

            _carriedObject = null;
        }
    }
}