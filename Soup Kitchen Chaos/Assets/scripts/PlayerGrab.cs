using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;

    private Food target;

    [SerializeField] SpriteRenderer foodSprite;

    [SerializeField] GameObject drop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bool state = Physics2D.queriesHitTriggers;
            Physics2D.queriesHitTriggers = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, interactionRange,interactableLayer);
            Physics2D.queriesHitTriggers = state;

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<PropBehaviour>(out PropBehaviour pb))
                {
                    SetFood(pb.food);
                    Destroy(pb.gameObject);
                } else if (hit.collider.TryGetComponent<IStorable<Food>>(out IStorable<Food> storable))
                {
                    Food f = storable.Retrieve(gameObject);
                    if (f != null)
                        SetFood(f);
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && target != null)
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, interactionRange,interactableLayer);

            if (hit.collider != null && hit.collider.TryGetComponent<IStorable<Food>>(out IStorable<Food> storable))
            {
                if (storable.Store(gameObject, target))
                {
                    target = null;
                    foodSprite.sprite = null;
                }
            }
            else
            {
                GameObject g = Instantiate(drop);
                PropBehaviour prop = g.GetComponent<PropBehaviour>();
                prop.SetFood(target);
                target = null;
                foodSprite.sprite = null;
                prop.transform.position = transform.position + transform.up;
            }
        }
    }

    public void SetFood(Food f)
    {
        target = f;
        foodSprite.sprite = f.sprite;
    }
}
