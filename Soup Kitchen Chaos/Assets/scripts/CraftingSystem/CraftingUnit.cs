using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftingUnit : MonoBehaviour, IInteractable
{
    [SerializeField]private List<CraftingRecipe> recipes = new List<CraftingRecipe>();

    public Container container;

    public Food output { get; protected set; }

    public float craftingSpeed;

    public GameObject minigame;

    public UnityEvent<Food> onCrafted;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Put(Food ingredient)
    {
        container.AddIngredient(ingredient);
    }


    public virtual void Craft()
    {
        CraftingRecipe recipe = FindRecipe();

        if (recipe == null)
            return;

        //output = new Food(recipe.output);
        BeginMinigame(new Food(recipe.output,recipe.burnTime,recipe.heatingDuration));
     //   OnCraft(recipe);
    }

    protected virtual void OnCraft(Food prize)
    {
    }

    protected CraftingRecipe FindRecipe()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i].IsRecipeValid(container.ingredients))
            {
                return recipes[i];
            }
        }

        return null;
    }

    public virtual void Interact(GameObject instigator)
    {

    }

    public GameObject BeginMinigame(Food prize)
    {
        if (minigame == null)
        {
            MakeCraft(prize);

            return null;
        }
        GameObject mgobj = Instantiate(minigame);
        Minigame mg = mgobj.GetComponent<Minigame>();
        mg.onCompleted.AddListener(() => {
            MakeCraft(prize);
        });
        

        return mgobj;
    }

    protected void MakeCraft(Food prize)
    {
        output = prize;
        OnCraft(prize);
        onCrafted?.Invoke(prize);
    }
}
