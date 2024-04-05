using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCraftingUnit : CraftingUnit
{
    public float burnedTime = 10;
    protected override void OnCraft(CraftingRecipe recipe)
    {
        
    }

    private void Update()
    {
        if (output.workingProgress<= -burnedTime)
        {
            output.isBurned = true;
        }
    }
}
