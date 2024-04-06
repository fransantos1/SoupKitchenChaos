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
            Debug.Log("Output: " + output); 
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
        Debug.Log(recipe);
        if (recipe == null)
            return;
        Debug.Log("Returned?");

        if (output == null)
        {
            output = new Food(recipe.output,recipe.burnTime,recipe.heatingDuration,recipe.outputSprite);
            Debug.Log("Output: " + output);
        }
    }
}
