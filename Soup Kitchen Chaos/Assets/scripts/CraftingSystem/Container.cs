using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Container
{
    public List<Food> ingredients;

    public enum ContainerType
    {
        None,
        Plate,
        Pan
    }

    public ContainerType containerType;

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
    public Food RemoveIngredient(GameObject gameobject)
    {
        if (ingredients.Count == 0)
            return null;
        Food send = ingredients[ingredients.Count - 1];
        ingredients.RemoveAt(ingredients.Count-1);
        return send;
    }
}
