using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBehaviour : MonoBehaviour
{
    public Food food;

    [SerializeField] private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        if (rend != null && food != null)
        {
            rend.sprite = food.sprite;
        }
    }

    public void SetFood(Food f)
    {
        this.food = f;
        if (rend != null)
        {
            rend.sprite = f.sprite;
        }
    }
}
