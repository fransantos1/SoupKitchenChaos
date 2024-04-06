using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string ingrediente;
    public Sprite sprite;
    public virtual void Interact(GameObject instigator)
    {
        instigator.GetComponent<PlayerGrab>().SetFood(new Food(new Ingredient(ingrediente,1)), sprite);
    }
}
