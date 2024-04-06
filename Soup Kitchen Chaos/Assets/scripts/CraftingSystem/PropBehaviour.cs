using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBehaviour : MonoBehaviour
{
    public Food food;
    public Sprite sprite;

    [SerializeField] private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        if (rend != null)
        {
            rend.sprite = sprite;
        }
    }

    public void SetFood(Food f,Sprite s)
    {
        this.food = f;
        this.sprite = s;
        if (rend != null)
        {
            rend.sprite = s;
        }
    }
}
