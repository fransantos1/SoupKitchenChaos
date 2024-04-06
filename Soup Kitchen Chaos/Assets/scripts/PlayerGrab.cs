using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;

    public GameObject target;
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

            if (hit.collider != null)
            {
                IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();

                if (interactableObject != null)
                {
                    interactableObject.Interact(gameObject);
                }
            }
        }
    }
}
