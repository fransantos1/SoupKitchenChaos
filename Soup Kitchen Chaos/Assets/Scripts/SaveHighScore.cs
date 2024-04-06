using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighScore : MonoBehaviour
{
    private const string HighScoreKey = "HIGHSCORE";

    private static int highscore;

    public static int Highscore
    {
        get { return highscore; }
        set
        {
            highscore = value;
            PlayerPrefs.SetInt(HighScoreKey, highscore);
        }
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
