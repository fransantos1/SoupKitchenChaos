using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCraftingUnit : CraftingUnit
{
    private Food cachedFood;
    private void Update()
    {
        if (output != null)
        {
            if (output.cookedTime > -1)
            {
                output.heatingProgress += Time.deltaTime * craftingSpeed;
            }
            if (output.isBurned && cachedFood != output)
            {
                onCrafted?.Invoke(output);
                OnCraft(output);
                output = new Food(scrapFood);
                cachedFood = output;
                return;
            }
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
            container.ingredients.Clear();
            output = new Food(recipe.output,recipe.burnTime,recipe.heatingDuration,recipe.outputSprite);
        }
    }
}
