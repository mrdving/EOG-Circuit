using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GM : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TMP_score;

    public GameObject[] UI_lives;
    public TMPro.TextMeshProUGUI TMP_lives;

    public GameObject UI_GameOver;

    private void Start()
    {
        UI_GameOver.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        TMP_score.text = "Score : " + score.ToString();
    }

    public void UpdateLives(int lives)
    {
        if(lives > 5)
        {
            for (int i = 0; i < 5; i++)
            {
                UI_lives[i].SetActive(i == 2); //Keep one as icon
            }
            TMP_lives.text = ": " + lives.ToString();
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                UI_lives[i].SetActive(i < lives);
            }
            TMP_lives.text = "";
        }
    }
    public void GameOver()
    {
        UI_GameOver.SetActive(true);
    }


}
