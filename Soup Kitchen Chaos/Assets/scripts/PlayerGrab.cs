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
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, interactionRange, interactableLayer);
            Debug.Log(hit.collider);

            if (hit.collider != null && hit.collider.TryGetComponent<PropBehaviour>(out PropBehaviour pb))
            {
                SetFood(pb.food,pb.sprite);
                Destroy(pb.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && target != null)
        {
            GameObject g = Instantiate(drop);
            PropBehaviour prop = g.GetComponent<PropBehaviour>();
            SpriteRenderer rnd = g.GetComponent<SpriteRenderer>();
            prop.food = target;
            target = null;
            prop.sprite = foodSprite.sprite;
            foodSprite.sprite = null;
            rnd.sprite = prop.sprite;
            rnd.transform.position = transform.position;

        }
    }

    public void SetFood(Food f,Sprite sprite)
    {
        target = f;
        foodSprite.sprite = sprite;
    }
}
