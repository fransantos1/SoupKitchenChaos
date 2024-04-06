using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MinigameBase : MonoBehaviour
{
    public UnityEvent onCompleted;


    public abstract void OnSetup(CraftingUnit craftUnit);

}
