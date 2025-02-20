using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualProductFoodObject : FoodObjectBase
{
    public ProducedFood producedFoodPrefab;

    void Start()
    {
        UpdateFoodAmountText();
        UpdateProgressBar();
    }

    public override void Interact()
    {
        if(_isBroken)
        {
            TryFix();
            return;
        }

        TryProduceFood();
    }

    public override void PickUp()
    {
        TakeFood();
    }

    private void TryProduceFood()
    {
        _productionPhase++;
        UpdateProgressBar();

        if (_productionPhase == _productionCost)
        {
            _productionPhase = 0;
            UpdateProgressBar();
            ProduceFood();
        }
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

    protected override void ProduceFood()
    {
        _foodAmount++;
        Punch();
        UpdateFoodAmountText();
    }
}