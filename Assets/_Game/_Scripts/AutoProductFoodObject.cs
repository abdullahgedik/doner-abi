using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProductFoodObject : FoodObjectBase
{
    private float _productionPhase = 0;

    private void Start()
    {
        UpdateFoodAmountText();
        UpdateProgressBar();
        StartCoroutine(AutoProduceFoodRoutine());
    }

    private void Update()
    {
        if (_productionPhase >= _productionCost)
        {
            _productionPhase = 0;
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
    }

    private IEnumerator AutoProduceFoodRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_productionCost);
            ProduceFood();
            Debug.Log("Auto producing food");
        }
    }

    protected override void UpdateProgressBar()
    {
        _progressBarImage.fillAmount = _productionPhase / _productionCost;
    }
}
