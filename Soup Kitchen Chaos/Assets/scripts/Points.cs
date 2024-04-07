using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points;

    public void AddPoints(int newpoints)
    {
        points += newpoints;
        Debug.Log(points);
    }
    public void SavePoints()
    {
        int lastHighScore = PlayerPrefs.GetInt("HIGHSCORE");
        Debug.Log(lastHighScore);
        if(points > lastHighScore) 
        {
            PlayerPrefs.SetInt("HIGHSCORE", points);
            PlayerPrefs.Save();
        }
    }
}
