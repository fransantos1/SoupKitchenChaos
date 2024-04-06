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

    public void SetFood(Food f)
    {
        this.food = f;
        this.sprite = f.sprite;
        if (rend != null)
        {
            rend.sprite = f.sprite;
        }
    }
}
