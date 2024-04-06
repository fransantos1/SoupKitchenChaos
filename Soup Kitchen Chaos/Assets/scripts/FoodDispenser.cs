using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDispenser : MonoBehaviour, IInteractable
{
    public string ingrediente;
    public Sprite sprite;

    public virtual void Interact(GameObject instigator)
    {
        Debug.Log(instigator);
        instigator.GetComponent<PlayerGrab>().SetFood(new Food(new Ingredient(ingrediente,1),sprite));
    }
}
