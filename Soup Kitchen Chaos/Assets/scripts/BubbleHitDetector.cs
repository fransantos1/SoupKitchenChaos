using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BubbleHitDetector : MonoBehaviour, IPointerEnterHandler
{
    public BubbleHitDetector previous;

    public bool isBroken { get; protected set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (previous == null)
        {
            isBroken = true;
            gameObject.SetActive(false);
            return;
        }
       
        if (previous.isBroken)
        {
            isBroken = true;
        }

        if (isBroken)
        {
            gameObject.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
