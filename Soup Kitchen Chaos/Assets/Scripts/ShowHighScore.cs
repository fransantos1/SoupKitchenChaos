using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    

    // Start is called before the first frame update
    void Start()
    {
        int highScore = SaveHighScore.Highscore;

        textMesh.text = "High Score: " + highScore + ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
