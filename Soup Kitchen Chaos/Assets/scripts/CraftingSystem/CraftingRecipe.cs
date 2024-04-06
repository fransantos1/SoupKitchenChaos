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

    public Sprite outputSprite;

    public Container.ContainerType containerType;

    [SerializeField] bool isOrdered;

    public bool IsRecipeValid(Container container)
    {
        List<Food> foods = container.ingredients;
        if (container.containerType != containerType)
            return false;

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
    public float cookedTime;

    public bool isCooked => heatingProgress >= cookedTime;

    public bool isBurned => heatingProgress >= burnTime;

    public Sprite sprite;

    public Food(Ingredient ingr)
    {
        this.ingredient = ingr;
    }

    public Food(Ingredient ingr,Sprite sprite)
    {
        this.ingredient = ingr;
        this.sprite = sprite;
    }

    public Food(Ingredient ingr,float burnTime,float cookedTime)
    {
        this.ingredient = ingr;
        this.burnTime = burnTime;
        this.cookedTime = cookedTime;
    }

    public Food(Ingredient ingr, float burnTime, float cookedTime,Sprite sprite)
    {
        this.ingredient = ingr;
        this.burnTime = burnTime;
        this.cookedTime = cookedTime;
        this.sprite = sprite;
    }

    public override string ToString()
    {
        return ingredient.ToString() + " - " + heatingProgress;
    }
}