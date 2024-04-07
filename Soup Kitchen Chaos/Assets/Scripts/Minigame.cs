using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Minigame : MinigameBase
{
    // Start is called before the first frame update
    public List<Vector2> points = new List<Vector2>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private int OffsetSize = 50;
    public Image minigameImage;
    public Sprite minigameSprite;
    [SerializeField] private Sprite checkpointSprite;

    public BubbleHitDetector lastBubble;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (lastBubble == null)
        {
            EndGame();
            return;
        }

       if (lastBubble.isBroken)
        {
            EndGame();
            return;
        }
    }
    void EndGame()
    {
        onCompleted?.Invoke();
        Destroy(gameObject);
    }

    public override void OnSetup(CraftingUnit craftUnit)
    {
        points = new List<Vector2>(craftUnit.nodes);
        minigameSprite = craftUnit.challengeSprite;
    }

    public Vector2 GetPoint(Vector2 originalPoint)
    {
        return originalPoint;
    }
}
