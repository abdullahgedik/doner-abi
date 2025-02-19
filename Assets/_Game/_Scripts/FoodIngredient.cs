using UnityEngine;
using System;

[Serializable]
public class FoodIngredient
{
    [SerializeField] public FoodType foodType;

    public FoodIngredient(FoodType foodType)
    {
        this.foodType = foodType;
    }
}

public enum FoodType
{
    Meat,
    Chicken,
    Tomato,
    Lettuce,
    Pickles,
    Bread,
    Sauce
}