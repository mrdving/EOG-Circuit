using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionIndicator_Player : MonoBehaviour
{
    public float pitch;
    public AudioClip clip;
    private AudioSource src;


    private void Start()
    {
        src = GetComponent<AudioSource>();
        src.pitch = pitch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag != "Player") return;
        if (src == null) return;
        src.PlayOneShot(clip);
    }
}
