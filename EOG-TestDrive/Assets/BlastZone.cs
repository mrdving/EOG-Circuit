using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastZone : MonoBehaviour
{
    Lives_GM GM;

    private void Start()
    {
        GM = FindObjectOfType<Lives_GM>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        switch (collision.gameObject.tag)
        {
            case "Ball":
                GM.AddLife(-1);
                
                break;
        }
        Destroy(collision.gameObject);
    }
}
