using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public int score = 1;
    public int health = 1;
    public GameObject fx_Death;
    public bool invincible = false;
    private AudioSource src;
    public AudioClip hit_clip;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public virtual bool TakeDamge(int damage)
    {
        src.PlayOneShot(hit_clip);
        if (invincible) return false;
        health -= damage;
        if (health <= 0) OnDeath();
        return true;
    }

    protected virtual void OnDeath()
    {
        Instantiate(fx_Death, transform.position, transform.rotation);
        FindObjectOfType<Scores_GM>().Score(score);
        gameObject.SetActive(false);
    }
}
