using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("Joystick Button 0"))
        {
            Debug.Log("Clicked  XX");
        }
        if (Input.GetKey("Joystick Button 1"))
        {
            Debug.Log("Clicked  00");
        }

    }
}
