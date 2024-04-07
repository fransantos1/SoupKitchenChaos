using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateGIf : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> sprites = new List<Sprite>();
    private float current;
    public float delay = 0.5f;


    public int imageIndex = 0;
    void Update()
    {

        if (current < delay)
        {
            current += Time.deltaTime;
        }
        if (current > delay)
        {
            transform.GetComponent<Image>().sprite = sprites[imageIndex];
            Debug.Log(sprites[imageIndex]);
            if(imageIndex == sprites.Count - 1) 
            {
                imageIndex = 0;
            }
            else
            {
                imageIndex++;
            }

            current = 0;
        }
        
    }
}
