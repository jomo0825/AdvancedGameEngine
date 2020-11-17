using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //成員變數 member variables
    //1.持續性輸入
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    public string keyA = "j";
    public string keyJump = "k";

    public string keyJup = "up";
    public string keyJdown = "down";
    public string keyJleft = "left";
    public string keyJright = "right";

    //2. 一次性輸入
    private bool lastJump = false;
    private bool newJump = false;
    public bool jump = false;

    //3. 雙擊 double clicks


    public float tempDup;
    public float tempDright;
    public float Dup;
    public float Dright;
    public float Jup;
    public float Jright;
    public float targetDup;
    public float targetDright;
    public float curVelocityDup;
    public float curVelocityDright;
    public float Dmag;
    public Vector3 Dvec;
    public bool run;
    public bool inputEnable = true;


    //成員方法 member methods
    void Update()
    {
        if (inputEnable == true)
        {
            targetDup = ((Input.GetKey(keyUp)) ? 1.0f : 0) - ((Input.GetKey(keyDown)) ? 1.0f : 0);
            targetDright = ((Input.GetKey(keyRight)) ? 1.0f : 0) - ((Input.GetKey(keyLeft)) ? 1.0f : 0);

            Jup = ((Input.GetKey(keyJup)) ? 1.0f : 0) - ((Input.GetKey(keyJdown)) ? 1.0f : 0);
            Jright = ((Input.GetKey(keyJright)) ? 1.0f : 0) - ((Input.GetKey(keyJleft)) ? 1.0f : 0);

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

    private Vector2 Mapping_Elliptical(float tempDright, float tempDup)
    {
        Vector2 output;

        output.x = tempDright * Mathf.Sqrt(1 - tempDup * tempDup / 2);
        output.y = tempDup * Mathf.Sqrt(1 - tempDright * tempDright / 2);

        return output;
    }

    private Vector2 Mapping_No(float tempDright, float tempDup)
    {
        Vector2 output;

        output.x = tempDright;
        output.y = tempDup;

        return output;
    }
}



