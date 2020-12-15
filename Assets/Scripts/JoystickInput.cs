using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : PlayerInput
{
    void Start()
    {
        keyA = "joystick button 0";
        keyJump = "joystick button 1";
    }

    //成員方法 member methods
    void Update()
    {
        if (inputEnable == true)
        {
            //targetDup = ((Input.GetKey(keyUp)) ? 1.0f : 0) - ((Input.GetKey(keyDown)) ? 1.0f : 0);
            //targetDright = ((Input.GetKey(keyRight)) ? 1.0f : 0) - ((Input.GetKey(keyLeft)) ? 1.0f : 0);

            targetDup = Input.GetAxis("Dup");
            targetDright = Input.GetAxis("Dright");

            //Jup = ((Input.GetKey(keyJup)) ? 1.0f : 0) - ((Input.GetKey(keyJdown)) ? 1.0f : 0);
            //Jright = ((Input.GetKey(keyJright)) ? 1.0f : 0) - ((Input.GetKey(keyJleft)) ? 1.0f : 0);

            Jup = Input.GetAxis("Jup");
            Jright = Input.GetAxis("Jright");

            run = Input.GetKey(keyA);
            newJump = Input.GetKey(keyJump);
        }
        else
        {
            targetDup = 0;
            targetDright = 0;
            run = false;
            newJump = false;
        }

        //tempDup = Mathf.Lerp (tempDup, targetDup, 0.1f);
        //tempDright = Mathf.Lerp (tempDright, targetDright, 0.1f);

        tempDup = Mathf.SmoothDamp(tempDup, targetDup, ref curVelocityDup, 0.1f);
        tempDright = Mathf.SmoothDamp(tempDright, targetDright, ref curVelocityDright, 0.1f);

        Vector2 tempVec = Mapping_Elliptical(tempDright, tempDup);
        Dright = tempVec.x;
        Dup = tempVec.y;

        Dmag = Mathf.Sqrt(Dup * Dup + Dright * Dright);
        Dvec = new Vector3(Dright, 0, Dup).normalized;

        //transform.position = new Vector3(tempDright, 0, tempDup);
     
        if (newJump != lastJump)
        {
            //print("跳吧!");
            if (newJump == true)
            {
                jump = true;
                //print("按壓");
            }
            else
            {
                jump = false;
                //print("鬆手");
            }
        }
        else
        {
            jump = false;
        }
        lastJump = newJump;
    }
       
}



