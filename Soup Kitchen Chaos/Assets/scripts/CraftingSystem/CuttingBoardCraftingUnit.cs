using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardCraftingUnit : CraftingUnit
{
    private bool isCutting;

    public void Cutting()
    {
        
    }

    public override void Interact(GameObject instigator)
    {
        Cutting();
    }
}
