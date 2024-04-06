using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCrafting : MonoBehaviour
{
    public CraftingUnit craftingUnit;
    public Ingredient input;
    // Start is called before the first frame update
    void Start()
    {
        if (craftingUnit != null)
        {
            craftingUnit.Put(new Food(input));
            craftingUnit.onCrafted.AddListener((Food f) =>
            {
                Debug.Log(f);

            });
            craftingUnit.Craft();

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
