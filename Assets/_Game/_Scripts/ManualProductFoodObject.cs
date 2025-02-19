using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualProductFoodObject : FoodObjectBase
{
    private int _productionPhase = 0;

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
    }

    protected override void ProduceFood()
    {
        _foodAmount++;
        Punch();
        UpdateFoodAmountText();
    }

    protected override void UpdateProgressBar()
    {
        _progressBarImage.fillAmount = _productionPhase / _productionCost;
    }
}
