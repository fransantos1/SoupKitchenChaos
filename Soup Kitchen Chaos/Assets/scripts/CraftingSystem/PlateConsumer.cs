using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateConsumer : CraftingUnit
{
    public CraftingRecipe activeRecipe;
    public GameObject Costumer;
    public Points points;
    public Animator animator;
    public GenerateRecipe gen;
    private float delay = 3;
    private float current = 0;
    public override void Craft()
    {

        activeRecipe = Costumer.GetComponent<GenerateRecipe>().chosenRecipe;
        CraftingRecipe recipe = FindRecipe();


        if (recipe == null)
            return;

        if (recipe == activeRecipe)
        {
            container.ingredients.Clear();
            animator.SetBool("interacted", true);
            current = 0;
            gen.chooseRecipe();
            points.AddPoints(20);

        }
        else
        {
            points.AddPoints(5);
            Debug.Log("Valid recipie not correct");
        }


    }

    void Update()
    {
        if (current< delay)
        {
            current += Time.deltaTime;
        }
        if(current > delay)
        {
            animator.SetBool("interacted", false);
        }
            
    }
}
