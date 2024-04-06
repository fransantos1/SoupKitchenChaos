using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CraftingUnit : MonoBehaviour, IInteractable, IStorable<Food>
{
    [SerializeField]private List<CraftingRecipe> recipes = new List<CraftingRecipe>();

    public Container container;

    public Food output { get; protected set; }

    public float craftingSpeed;

    public GameObject minigame;

    public Sprite challengeSprite;

    public UnityEvent<Food> onCrafted;

    public List<Vector2> nodes;

    [SerializeField]protected Food scrapFood;


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
        BeginMinigame(new Food(recipe.output,recipe.burnTime,recipe.heatingDuration,recipe.outputSprite));
     //   OnCraft(recipe);
    }

    protected virtual void OnCraft(Food prize)
    {
    }

    protected CraftingRecipe FindRecipe()
    {

        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i].IsRecipeValid(container))
            {
                Debug.Log(recipes[i]);
                return recipes[i];
            }
        }

        return null;
    }

    public virtual void Interact(GameObject instigator)
    {
        if (output == null)
        {
            Craft();
        } else {
            PlayerGrab grab = instigator.GetComponent<PlayerGrab>();
            grab.SetFood(output);
            output = null;
            //container.ingredients.Clear();
        }
    }

    public virtual bool Store(GameObject instigator,Food item)
    {
        Debug.Log(item.ToString());
        for(int i = 0;i < recipes.Count; i++)
        {
            if (recipes[i].ingredients.Contains(item.ingredient))
            {
                Put(item);
                return true;
            }
        }
        return false;    
    }
    public virtual Food Retrieve(GameObject instigator)
    {
        return container.RemoveIngredient(instigator);
    }

    public GameObject BeginMinigame(Food prize)
    {
        if (minigame == null)
        {
            MakeCraft(prize);

            return null;
        }
        GameObject mgobj = Instantiate(minigame);
        MinigameBase mg = mgobj.GetComponent<MinigameBase>();
        mg.OnSetup(this);

        mg.onCompleted.AddListener(() => {
            MakeCraft(prize);
        });
        

        return mgobj;
    }

    protected void MakeCraft(Food prize)
    {
        container.ingredients.Clear();
        output = prize;
        OnCraft(prize);
        onCrafted?.Invoke(prize);
    }
}
