using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour
{
    public CapsuleCollider col;
    public Vector3 onGroundOffset = new Vector3(0, -0.1f, 0); 

    private Vector3 point0;
    private Vector3 point1;
    private float radius;

    // Update is called once per frame
    void FixedUpdate()
    {
        radius = col.radius;
        point0 = col.transform.position + radius * Vector3.up + onGroundOffset;
        point1 = col.transform.position + col.height * Vector3.up - radius * Vector3.up + onGroundOffset;

        Collider[] tempCols = Physics.OverlapCapsule(point0, point1, radius, LayerMask.GetMask("Ground"));

        if (tempCols.Length >0)
        {
            SendMessageUpwards("IsGround");
        }
        else
        {
            SendMessageUpwards("IsNotGround");
        }

        //foreach (Collider tempCol in tempCols)
        //{
        //    print(tempCol.name);
        //}
        
    }
}
