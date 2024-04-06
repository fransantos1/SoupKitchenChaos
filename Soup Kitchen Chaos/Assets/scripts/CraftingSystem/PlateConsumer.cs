using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateConsumer : CraftingUnit
{
    public string activeRecipe;
    public override void Craft()
    {
        CraftingRecipe recipe = FindRecipe();
        if (recipe == null)
            return;

        if (recipe.name == activeRecipe)
        {
            container.ingredients.Clear();


        }


    }
}
