using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//這是我的抽象類別
public abstract class PlayerInput : MonoBehaviour
{
    public string keyUp;
    public string keyDown;
    public string keyLeft;
    public string keyRight;
    public string keyA;
    public string keyJump;

    public string keyJup;
    public string keyJdown;
    public string keyJleft;
    public string keyJright;

    //2. 一次性輸入
    protected bool lastJump = false;
    protected bool newJump = false;
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

    protected Vector2 Mapping_Elliptical(float tempDright, float tempDup)
    {
        Vector2 output;

        output.x = tempDright * Mathf.Sqrt(1 - tempDup * tempDup / 2);
        output.y = tempDup * Mathf.Sqrt(1 - tempDright * tempDright / 2);

        return output;
    }

    protected Vector2 Mapping_No(float tempDright, float tempDup)
    {
        Vector2 output;

        output.x = tempDright;
        output.y = tempDup;

        return output;
    }
}
