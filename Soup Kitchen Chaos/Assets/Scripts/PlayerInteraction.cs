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
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, interactionRange);
            Debug.Log(hit.collider);

            if(hit.collider != null)
            {
                IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();

                if (interactableObject != null)
                {
                    interactableObject.Interact(gameObject);
                }
            }
        }


        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);

            foreach(Collider2D collider in hitColliders)
            {
                InteractableObject interactableObject = collider.GetComponent<InteractableObject>();

                if (interactableObject != null)
                {
                    interactableObject.Interact();
                }
            }
        }
        */
    }
        
}
