using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int initialScore = 0;
    public static int score;
    public int scoreUpdate;
    public Text scoreUI;

    private void Awake() 
    {
        scoreUI.text = initialScore.ToString();
    }

    // Update is called once per frame

    public static void UpdateScore(int newScore) 
    {
        Debug.Log("Score Updated: Added " + newScore + " points!");
        score += newScore;
    }

    void LateUpdate()
    {
        scoreUI.text = initialScore.ToString();

        initialScore = score;
    }
}
