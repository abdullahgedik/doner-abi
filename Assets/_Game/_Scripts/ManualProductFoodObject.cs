using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualProductFoodObject : FoodObjectBase
{
    private bool _isProducingFood = false;
    
    public override void Interact()
    {
        ProduceFood();
    }

    private void ProduceFood()
    {
        _isProducingFood = true;

        StartCoroutine(ProduceFoodRoutine());
    }

    private IEnumerator ProduceFoodRoutine()
    {
        while (_isProducingFood)
        {
            yield return new WaitForSeconds(_productionDuration);
            Debug.Log("Food produced");
            _isProducingFood = false;
            TakeFood();
        }
    }

    protected override void TakeFood()
    {
        Debug.Log("Taking food");
    }
}
