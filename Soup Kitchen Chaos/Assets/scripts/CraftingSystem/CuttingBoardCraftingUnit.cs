using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardCraftingUnit : CraftingUnit
{
    private bool isCutting;
    protected override void OnCraft(CraftingRecipe recipe)
    {
        base.OnCraft(recipe);
        output = new Food(recipe.output);
    }

    public void Cutting()
    {
        output.workingProgress += craftingSpeed;
        if (output.isCompleted)
        {

        }
    }
}
