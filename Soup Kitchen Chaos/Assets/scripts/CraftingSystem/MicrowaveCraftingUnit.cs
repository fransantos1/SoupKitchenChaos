using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveCraftingUnit : CraftingUnit
{

    private void Update()
    {
        if (output != null)
        {
            output.heatingProgress += Time.deltaTime * craftingSpeed;
        }
    }
}
