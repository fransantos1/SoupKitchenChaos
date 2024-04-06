using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Container
{
    public List<Food> ingredients;

    public bool isDirty;

    public Container()
    {
        this.ingredients = new List<Food>();
        this.isDirty = true;
    }

    public void AddIngredient(Food food)
    {
        ingredients.Add(food);
        isDirty = true;
    }
}
