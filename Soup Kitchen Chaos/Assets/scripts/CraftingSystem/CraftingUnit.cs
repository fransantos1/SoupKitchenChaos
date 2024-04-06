using System.Collections;
using System.Collections.Generic;
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
        BeginMinigame(recipe,new Food(recipe.output,recipe.burnTime,recipe.heatingDuration,recipe.outputSprite));
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
        } else
        {
            PlayerGrab grab = instigator.GetComponent<PlayerGrab>();
            grab.SetFood(output);

            output = null;
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

    public GameObject BeginMinigame(CraftingRecipe recipe,Food prize)
    {
        if (minigame == null)
        {
            MakeCraft(prize);

            return null;
        }
        GameObject mgobj = Instantiate(minigame);
        Minigame mg = mgobj.GetComponent<Minigame>();
        mg.points = new List<Vector2>(recipe.nodes);
        mg.minigameSprite = challengeSprite;
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
