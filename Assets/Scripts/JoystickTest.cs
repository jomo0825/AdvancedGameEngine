using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("Jright value:" + Input.GetAxis("Jright"));
        //print("Jup value:" + Input.GetAxis("Jup"));

        print("btn0 value:" + Input.GetKey("joystick button 0"));
        print("btn1 value:" + Input.GetKey("joystick button 1"));
        print("btn2 value:" + Input.GetKey("joystick button 2"));
        print("btn3 value:" + Input.GetKey("joystick button 3"));

    }
}
