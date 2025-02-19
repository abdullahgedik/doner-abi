using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducedFood : MonoBehaviour
{
    [SerializeField] private FoodType foodType;

    public FoodType FoodType => foodType;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetKinematic(bool isKinematic)
    {
        _rb.isKinematic = isKinematic;
    }
}
