using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionIndicatorManager : MonoBehaviour
{
    public Transform[] positionIndicators;
    public Color color_L;
    public Color color_R;

    public Vector3 boundary_L;
    public Vector3 boundary_R;

    public float pitch_L;
    public float pitch_R;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        positionIndicators = transform.GetComponentsInChildren<Transform>(true);

        for(int i = 1; i < positionIndicators.Length; i++)
        {
            //Debug.Log("i = " + i + " lerp = " + (float)(i - 1) / (positionIndicators.Length - 2));
            positionIndicators[i].gameObject.SetActive(true);
            positionIndicators[i].gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(color_L, color_R, (float)(i-1) / (positionIndicators.Length-1));
            positionIndicators[i].gameObject.GetComponent<PositionIndicator_Player>().pitch = Mathf.Lerp(pitch_L, pitch_R, (float)(i-1) / (positionIndicators.Length-1));
            positionIndicators[i].localPosition = Vector3.Lerp(boundary_L, boundary_R, (float)(i-1) / (positionIndicators.Length-1));
        }
    }

}
