using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCrafting : MonoBehaviour
{
    public CraftingUnit craftingUnit;
    // Start is called before the first frame update
    void Start()
    {
        if (craftingUnit != null)
        {
            craftingUnit.Put(new Food(new Ingredient("Onion",1)));
            craftingUnit.Craft();
            Debug.Log(craftingUnit.output);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
