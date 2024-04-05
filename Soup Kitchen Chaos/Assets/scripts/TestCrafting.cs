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
            craftingUnit.Interact(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
