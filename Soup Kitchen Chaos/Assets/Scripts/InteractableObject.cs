using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public enum StationType
    {
        Oven,
        Stove,
        Sink,
        CuttingBoard,
        Washing,
        Microwave,
        Counter,
        Table,
        Ingredients
    }

    public void Interact(GameObject instigator)
    {

    }
}
