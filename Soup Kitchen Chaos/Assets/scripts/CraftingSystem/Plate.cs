using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate
{
    public Food food;

    public bool isDirty;

    public Plate(Food food)
    {
        this.food = food;
        this.isDirty = true;
    }

    public Plate()
    {
        this.isDirty = false;
    }
}
