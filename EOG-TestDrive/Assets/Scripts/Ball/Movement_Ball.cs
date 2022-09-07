using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Ball : MonoBehaviour
{
    //Components
    public LineRenderer line;
    public bool renderLine = true;
    //stats
    public float spd_ball;
    public Vector2 velo_init;
    public int damage = 1;
    //state
    private Vector2 velo_ball;

    private void Start()
    {
        velo_ball = velo_init;
        line = GetComponent<LineRenderer>();
        line.enabled = renderLine;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                OnPlayerCollision(collision.gameObject);
                break;
            case "Block":
                OnBlockCollision(collision);
                break;
        }
    }

    private void OnPlayerCollision(GameObject player)
    {
        velo_ball = spd_ball * (transform.position - player.transform.position).normalized;
        player.GetComponent<Movement_Player>().PlayHitSound();
    }

    private void OnBlockCollision(Collision2D collision)
    {
        //Debug.Log("B4" + velo_ball);
        Vector2 vec_norm = collision.contacts[0].normal;
        //Debug.Log("norm" + vec_norm);
        velo_ball = Vector2.Reflect(velo_ball, vec_norm);
        Debug.Log("after" + velo_ball);
        Block block = collision.gameObject.GetComponent<Block>();
        if (block == null) return;
        block.TakeDamge(damage);
    }

    private void Update()
    {
        if (!renderLine) return;
        if(velo_ball.y < 0)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + (Vector3)velo_ball*5);
        }
        else
        {
            line.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(velo_ball * Time.deltaTime);
    }


}
