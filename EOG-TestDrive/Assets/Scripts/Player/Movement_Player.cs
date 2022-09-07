using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour
{
    // Control
    public string ctrl_L = "a";
    public string ctrl_R = "d";
    //Stats
    public float spd_player = 1;
    public float boundary_L = 0;
    public float boundary_R = 100;
    //Status
    private Vector3 pos_playerInit;
    private float pos_player = 0;
    private float velo_player = 0;
    private Transform trnfm_player;
    private AudioSource src;
    public AudioClip hit_clip;
    
    // Start is called before the first frame update
    void Start()
    {
        trnfm_player = transform;
        pos_playerInit = trnfm_player.position;
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyInput();
    }
    
    void FixedUpdate(){
        HandlePlayerMovement();
    }

    private void OnDrawGizmos()
    {
        DrawMovementBoundary();
    }

    private void HandleKeyInput(){
        velo_player = 0;
        velo_player -= Input.GetKey(ctrl_L) ? spd_player : 0;
        velo_player += Input.GetKey(ctrl_R) ? spd_player : 0;
    }
    
    private void HandlePlayerMovement(){
        float pos_new = pos_player + velo_player * Time.deltaTime;
        pos_player = Mathf.Clamp(pos_new, boundary_L, boundary_R);
        trnfm_player.position = pos_playerInit + Vector3.right * pos_player;
    }

    private void DrawMovementBoundary()
    {
        Gizmos.DrawLine(transform.position + Vector3.right * boundary_L, transform.position + Vector3.right * boundary_R);
    }

    public void PlayHitSound()
    {
        src.PlayOneShot(hit_clip);
    }
}
