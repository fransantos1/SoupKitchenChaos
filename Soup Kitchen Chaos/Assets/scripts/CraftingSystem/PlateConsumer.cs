using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateConsumer : CraftingUnit
{
    public CraftingRecipe activeRecipe;
    public GameObject Costumer;
    public override void Craft()
    {
        activeRecipe = Costumer.GetComponent<GenerateRecipe>().chosenRecipe;
        CraftingRecipe recipe = FindRecipe();
        Debug.Log(recipe);
        Debug.Log(activeRecipe);
        if (recipe == null)
            return;

        if (recipe == activeRecipe)
        {
            Debug.Log("Correct Recipe");
            container.ingredients.Clear();
        }


    }
}
