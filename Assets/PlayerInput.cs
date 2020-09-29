﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public float Dup;
    public float Dright;
    public float targetDup;
    public float targetDright;
    public float curVelocityDup;
    public float curVelocityDright;

    void Update()
    {
        targetDup = ((Input.GetKey(keyUp)) ? 1.0f : 0) - ((Input.GetKey(keyDown)) ? 1.0f : 0);
        targetDright = ((Input.GetKey(keyRight)) ? 1.0f : 0) - ((Input.GetKey(keyLeft)) ? 1.0f : 0);

        //Dup = Mathf.Lerp (Dup, targetDup, 0.1f);
        //Dright = Mathf.Lerp (Dright, targetDright, 0.1f);

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref curVelocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref curVelocityDright, 0.1f);

        transform.position = new Vector3(Dright, 0, Dup);
    }
}

