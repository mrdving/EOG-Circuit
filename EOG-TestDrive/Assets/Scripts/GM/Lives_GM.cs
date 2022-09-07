using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives_GM : MonoBehaviour
{
    public int initLives = 3;
    private int totalLives = 3;
    private UI_GM UI;
    public GameObject ball;
    public AudioClip deathClip;
    private AudioSource src;

    private void Start()
    {
        totalLives = initLives;
        UI = GetComponent<UI_GM>();
        UI.UpdateLives(initLives);
        src = GetComponent<AudioSource>();
    }

    public void AddLife(int lives)
    {
        totalLives += lives;
        UI.UpdateLives(totalLives);
        if(totalLives < 0)
        {
            GameOver();
            return;
        }
        if(lives < 0)
        {
           StartCoroutine(CreateBall());
        }
    }

    public IEnumerator CreateBall()
    {
        src.PlayOneShot(deathClip);
        yield return new WaitForSeconds(2);
        Instantiate(ball);
        //Debug.Log("Ball created");
        yield return null;
    }

    private void GameOver() {
        Debug.Log("GameOver");
        UI.GameOver();
        return;
    }
}
