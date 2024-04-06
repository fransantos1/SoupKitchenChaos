using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveCrafting : CraftingUnit
{

    private Food cachedFood;
    private void Update()
    {
        if (output != null)
        {
            output.heatingProgress += Time.deltaTime * craftingSpeed;
            if (output.isCooked && cachedFood != output)
            {
                onCrafted?.Invoke(output);
                OnCraft(output);
                cachedFood = output;
            }
        }
    }

    public override void Craft()
    {
        CraftingRecipe recipe = FindRecipe();

        if (recipe == null)
            return;

        if (output == null)
        {
            output = new Food(recipe.output,recipe.burnTime,recipe.heatingDuration);
        }
    }
}