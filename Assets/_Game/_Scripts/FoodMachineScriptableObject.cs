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
        public float upgradeCost;
        [SerializeField]
        public float productionCost;
        [SerializeField]
        public float productCapacity;
    }

    [SerializeField] public FoodType _foodType;
    [SerializeField] public List<ProductionCostTimeUpgrade> _productionCostLevels;

    public FoodType GetFoodType()
    {
        return _foodType;
    }

    public float GetUpgradeCost(int level)
    {
        return _productionCostLevels[level - 1].upgradeCost;
    }

    public float GetProductionCost(int level)
    {
        return _productionCostLevels[level - 1].productionCost;
    }
}
