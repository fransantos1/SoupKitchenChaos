using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<Ingredient> ingredients;

    public float heatingDuration = -1;
    public bool requiresHeating => heatingDuration > -1;

    public Ingredient output;
}

[System.Serializable]
public struct Ingredient
{
    public string name;
    public int units;

    public Ingredient(string name,int units)
    {
        this.name = name;
        this.units = units;
    }

    public override string ToString()
    {
        return $"{name} x{units}";
    }
}

[System.Serializable]
public class Food
{
    public Ingredient ingredient;

    public float workingProgress;

    public bool isCompleted => workingProgress <= 0;

    public bool isBurned;

    public bool canBeUsed => isCompleted && !isBurned;

    public Food(Ingredient ingr)
    {
        this.ingredient = ingr;
    }

    public override string ToString()
    {
        return ingredient.ToString() + " - " + workingProgress;
    }
}