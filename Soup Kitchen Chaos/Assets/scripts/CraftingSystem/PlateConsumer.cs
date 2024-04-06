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
    public override void Craft()
    {
        activeRecipe = Costumer.GetComponent<GenerateRecipe>().chosenRecipe;
        CraftingRecipe recipe = FindRecipe();

        if (recipe == null)
            return;

        if (recipe == activeRecipe)
        {
            container.ingredients.Clear();
            animator.SetBool("interacted", false);
            gen.chooseRecipe();
            points.AddPoints(20);

        }
        else
        {
            points.AddPoints(5);
            Debug.Log("Valid recipie not correct");
        }


    }
}
