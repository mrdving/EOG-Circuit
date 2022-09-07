using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores_GM : MonoBehaviour
{
    private int totalScore = 0;
    private UI_GM UI;

    private void Start()
    {
        //bind components
        UI = GetComponent<UI_GM>();
        UI.UpdateScore(0);
    }

    public void Score(int score)
    {
        totalScore += score;
        UI.UpdateScore(totalScore);
    }
    public int GetScore()
    {
        return totalScore;
    }
}
