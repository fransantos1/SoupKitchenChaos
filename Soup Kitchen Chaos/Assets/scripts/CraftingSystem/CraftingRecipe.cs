using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<Ingredient> ingredients;

    public float heatingDuration = -1;

    public float burnTime = -1;
    public bool requiresHeating => heatingDuration > -1;

    public Ingredient output;

    [SerializeField] bool isOrdered;

    public bool IsRecipeValid(List<Food> foods)
    {
        if (isOrdered)
        {
            return IsOrderedValid(foods);
        } else
        {
            return IsUnorderedValid(foods);
        }
    }

    private bool IsOrderedValid(List<Food> foods)
    {
        bool state = ingredients.Count == foods.Count;
        if (state)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                Food food = foods[i];
                if (PredicateIngredient(food))
                {
                    state = false;
                    break;
                }
            }
        }

        return state;
    }

    private bool IsUnorderedValid(List<Food> foods)
    {
        bool state = foods.Count >= ingredients.Count;
        
        for (int i = 0; i < foods.Count; i++)
        {
            Food food = foods[i];
            if (PredicateIngredient(food))
            {
                state = false;
                break;
            }
        }


        return state;
    }

    private bool PredicateIngredient(Food food)
    {
        return !food.isBurned || !ingredients.Contains(food.ingredient);
    }
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

    public float heatingProgress;
    public float burnTime;

    public bool isCooked => heatingProgress <= 0;

    public bool isBurned => heatingProgress <= burnTime;

    public Food(Ingredient ingr)
    {
        this.ingredient = ingr;
    }

    public Food(Ingredient ingr,float burnTime)
    {
        this.ingredient = ingr;
        this.burnTime = burnTime;
    }

    public override string ToString()
    {
        return ingredient.ToString() + " - " + heatingProgress;
    }
}