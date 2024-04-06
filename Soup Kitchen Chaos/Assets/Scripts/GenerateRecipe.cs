using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GenerateRecipe : MonoBehaviour, IInteractable
{
    public List<CraftingRecipe> recipes;
    public List<GameObject> gameObjects;

    public CraftingRecipe chosenRecipe;

    public Animator animator;  

    // Start is called before the first frame update
    void Start()
    {        
        chooseRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact(GameObject instigator)
    {
        GameObject go = gameObjects[recipes.IndexOf(chosenRecipe)];

        go.SetActive(true);

        animator.SetBool("interacted", true);


    }
    public void chooseRecipe() 
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
        chosenRecipe = recipes[Random.Range(0, recipes.Count)];
    }
}
