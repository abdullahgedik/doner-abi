using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodMachine", menuName = "ScriptableObjects/FoodMachineScriptableObject", order = 1)]
public class FoodMachineScriptableObject : ScriptableObject
{
    [Serializable]
    public struct ProductionCostTimeUpgrade
    {
        [SerializeField]
        public float cost;
        [SerializeField]
        public float productionTime;
    }

    [SerializeField] public FoodIngredient _foodIngredient;
    [SerializeField] public List<ProductionCostTimeUpgrade> _productionTimeLevels;

    public FoodType GetFoodType()
    {
        return _foodIngredient.foodType;
    }

    public float GetCost(int level)
    {
        return _productionTimeLevels[level - 1].cost;
    }

    public float GetProductionTime(int level)
    {
        return _productionTimeLevels[level - 1].productionTime;
    }
}
