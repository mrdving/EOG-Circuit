using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject objTest;
    public GameObject objGame;

    private void Start()
    {
        objTest.SetActive(true);
        objGame.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            objTest.SetActive(false);
            objGame.SetActive(true);
        }
    }

}
