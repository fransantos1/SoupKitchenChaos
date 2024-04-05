using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUnit : MonoBehaviour, IInteractable
{
    [SerializeField]private List<CraftingRecipe> recipes = new List<CraftingRecipe>();
    private List<Food> ingredients = new List<Food>();

    public Food output;

    public float craftingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Put(Food ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void Craft()
    {
        CraftingRecipe recipe = FindRecipe();
        if (recipe == null)
            return;

        output = new Food(recipe.output);
        OnCraft(recipe);
    }

    protected virtual void OnCraft(CraftingRecipe recipe)
    {
        output = new Food(recipe.output);
    }

    private CraftingRecipe FindRecipe()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            CraftingRecipe recipe = recipes[i];
            for (int j = 0; j < ingredients.Count; j++)
            {
                Food food = ingredients[j];
                if (food.canBeUsed && recipe.ingredients.Contains(food.ingredient))
                {
                    return recipe;
                }
            }
        }

        return null;
    }

    public virtual void Interact(GameObject instigator)
    {

    }
}
