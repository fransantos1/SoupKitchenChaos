using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2f;
    public LayerMask interactableLayer;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, interactionRange,interactableLayer);

            if(hit.collider != null)
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
