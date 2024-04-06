using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour, IStorable<Food>
{
    //by doing nothing the item is being destroyed
    public bool Store(GameObject instigator,Food item)
    {
        return true;
    }

    public Food Retrieve(GameObject instigator)
    {
        return null;
    }
}
