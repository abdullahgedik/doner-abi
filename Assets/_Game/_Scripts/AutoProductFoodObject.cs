using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProductFoodObject : FoodObjectBase
{
    private void Start()
    {
        StartProduction();
    }

    public override void Interact()
    {
        TakeFood();
    }

    protected override void TakeFood()
    {
        if (_foodAmount == 0)
            return;

        _foodAmount--;
        Debug.Log("Taking food");
    }

    private void StartProduction()
    {
        StartCoroutine(AutoProduceFoodRoutine());
    }

    private IEnumerator AutoProduceFoodRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_productionDuration);
            Debug.Log("Auto producing food");
        }
    }
}
