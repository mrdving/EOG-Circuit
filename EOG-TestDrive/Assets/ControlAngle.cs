using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAngle : MonoBehaviour
{
    public Transform eye_L;
    public Transform eye_R;

    public Transform plus_L;
    public Transform plus_R;

    public Transform minus_L;
    public Transform minus_R;

    public float spdRotate = 30;
    public float angle = 0;
    public float scale = 1;

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            angle += spdRotate * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            angle -= spdRotate * Time.deltaTime;
        }

        eye_L.rotation = Quaternion.Euler(0, 0, angle);
        eye_R.rotation = Quaternion.Euler(0, 0, angle);

        float rad = Mathf.Deg2Rad * angle;
        if (angle > 0)
        {
            plus_L.localScale = new Vector3(Mathf.Sin(rad), Mathf.Sin(rad), 0) * scale;
            minus_L.localScale = Vector3.zero;
            plus_R.localScale = Vector3.zero;
            minus_R.localScale = new Vector3(Mathf.Sin(rad), Mathf.Sin(rad), 0) * scale;
        }
        else
        {
            plus_L.localScale = Vector3.zero;
            minus_L.localScale = new Vector3(Mathf.Sin(-rad), Mathf.Sin(-rad), 0) * scale;
            plus_R.localScale = new Vector3(Mathf.Sin(-rad), Mathf.Sin(-rad), 0) * scale;
            minus_R.localScale = Vector3.zero;
        }
        
    }
}
