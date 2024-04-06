using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GenerateRecipe : MonoBehaviour, IInteractable
{
    public List<CraftingRecipe> recipes;
    public List<GameObject> gameObjects;

    public CraftingRecipe chosenRecipe;     

    // Start is called before the first frame update
    void Start()
    {        
        chosenRecipe = recipes[Random.Range(0, recipes.Count - 1)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact(GameObject instigator)
    {
        GameObject go = gameObjects[recipes.IndexOf(chosenRecipe)];

        go.SetActive(true);
    }
}
