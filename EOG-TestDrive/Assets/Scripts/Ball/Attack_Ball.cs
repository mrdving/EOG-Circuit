using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ball : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Block block = collision.gameObject.GetComponent<Block>();
        if (block == null) return;

        block.TakeDamge(damage);
    }
}
