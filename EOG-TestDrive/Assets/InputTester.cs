using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    public string key;
    public Color off_color;
    public Color on_color;

    public AudioClip on_wav;
    public AudioClip off_wav;

    private SpriteRenderer SR;
    private AudioSource src;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(key))
        {
            SR.color = on_color;
        }
        else
        {
            SR.color = off_color;
        }

        if (Input.GetKeyDown(key))
        {
            src.PlayOneShot(on_wav);
        }
        if (Input.GetKeyUp(key))
        {
            src.PlayOneShot(off_wav);
        }

    }
}
