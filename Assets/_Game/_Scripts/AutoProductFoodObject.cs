using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProductFoodObject : FoodObjectBase
{
    public ProducedFood producedFoodPrefab;
    private bool _isProducing = false;

    private void Start()
    {
        UpdateFoodAmountText();
        UpdateProgressBar();
    }

    private void Update()
    {
        if (_isBroken)
            return;

        if (!_isProducing)
            return;
        
        if (_productionPhase >= _productionCost)
        {
            _productionPhase = 0;
            ProduceFood();
        }

        _productionPhase += Time.deltaTime;
        UpdateProgressBar();
    }

    public override void Interact()
    {
        if (_isBroken)
            TryFix();
    }

    public override void PickUp()
    {
        TakeFood();
    }

    protected override void ProduceFood()
    {
        _foodAmount++;
        Punch();
        UpdateFoodAmountText();
    }

    protected override void TakeFood()
    {
        if (_foodAmount == 0)
            return;

        Punch();
        _foodAmount--;
        UpdateFoodAmountText();

        Debug.Log("Taking food");
        Instantiate(producedFoodPrefab, transform.position, Quaternion.identity);
    }
}