using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMinigame : MinigameBase
{
    Vector3 ownerPosition;

    [SerializeField]Image fillImage;

    private Food food;


    private CraftingUnit unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fillImage != null && food != null)
        {
            fillImage.fillAmount = food.heatingProgress / food.cookedTime;
            if (unit.output != food)
            {
                onCompleted?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public override void OnSetup(CraftingUnit craftUnit)
    {
        ownerPosition = craftUnit.transform.position;

        transform.position = ownerPosition - transform.up;

        unit = craftUnit;

        food = craftUnit.output;

    }
}
