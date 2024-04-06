using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Minigame : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points = new List<Vector2>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private int OffsetSize = 50;
    public UnityEvent onCompleted;
    public Image minigameImage;
    public Sprite minigameSprite;
    [SerializeField] private Sprite checkpointSprite;


    void Start()
    {
        minigameImage.sprite = minigameSprite;
        for(int i = 0; i < points.Count; i++)
        {
            GameObject go = new GameObject("New Object");
            go.transform.position = points[i];
            go.transform.SetParent(transform, true);
            Image image = go.AddComponent<Image>();
            image.sprite = checkpointSprite;
            image.rectTransform.sizeDelta = new Vector2(25, 25);
            gameObjects.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (points.Count == 0)
        {
            EndGame();
            return;
        }
        if (Mathf.Pow((mousePos.x - points[points.Count - 1].x), 2) + Mathf.Pow((mousePos.y - points[points.Count - 1].y), 2) < Mathf.Pow(OffsetSize, 2))
        {
            Destroy(gameObjects[points.Count - 1]);
            gameObjects.RemoveAt(points.Count - 1);
            points.RemoveAt(points.Count - 1);  
            Debug.Log("Touching");
        }
    }
    void EndGame()
    {
        onCompleted?.Invoke();
        Destroy(gameObject);
    }
}
