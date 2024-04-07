using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCraftingUnit : CraftingUnit
{
    private Food cachedFood;
    private Food cachedFoodBurned;


    private void Update()
    {
        if (output != null)
        {
            if (output.cookedTime > -1)
            {
                output.heatingProgress += Time.deltaTime * craftingSpeed;
            }
            if (output.isBurned && cachedFoodBurned != output)
            {
                output = new Food(scrapFood);
                onCrafted?.Invoke(output);
                OnCraft(output);
                cachedFoodBurned = output;
                return;
            }
            if (output.isCooked && cachedFood != output)
            {
                onCrafted?.Invoke(output);
                OnCraft(output);
                cachedFood = output;
            }
        }
    }

    public override void Craft()
    {
        CraftingRecipe recipe = FindRecipe();
        if (recipe == null)
            return;

        if (output == null)
        {
            container.ingredients.Clear();
            // futureFood = new Food(recipe.output, recipe.burnTime, recipe.heatingDuration, recipe.outputSprite);
            output = new Food(recipe.output, recipe.burnTime, recipe.heatingDuration, recipe.outputSprite);
            GameObject mgobj = Instantiate(minigame);
            MinigameBase mg = mgobj.GetComponent<MinigameBase>();
            mg.OnSetup(this);
            /* if (g != null)
             {
                 g.SendMessage("SetFood", futureFood);
             }*/

        }
    }
    public override void Interact(GameObject instigator)
    {
        if (output == null)
        {
            Craft();
        }
        else
        {
            PlayerGrab grab = instigator.GetComponent<PlayerGrab>();
            if(output.heatingProgress <= output.cookedTime)
            {
                return;
            }
            else{
                grab.SetFood(output);
            }
            output = null;
            //container.ingredients.Clear();
        }
    }
}
