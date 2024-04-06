using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftingUnit : MonoBehaviour, IInteractable
{
    [SerializeField]private List<CraftingRecipe> recipes = new List<CraftingRecipe>();
    private List<Food> ingredients = new List<Food>();

    public Food output;

    public float craftingSpeed;

    public GameObject minigame;

    public UnityEvent<Food> onCrafted;

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

        //output = new Food(recipe.output);
        BeginMinigame(new Food(recipe.output));
     //   OnCraft(recipe);
    }

    protected virtual void OnCraft(CraftingRecipe recipe)
    {
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

    public GameObject BeginMinigame(Food prize)
    {
        GameObject mgobj = Instantiate(minigame);
        Minigame mg = mgobj.GetComponent<Minigame>();
        mg.onCompleted.AddListener(() => {

            output = prize;
            onCrafted?.Invoke(prize);
        });
        

        return mgobj;
    }
}
