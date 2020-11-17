using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCube : MonoBehaviour
{
    private Vector3 tempVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x +1, transform.eulerAngles.y, transform.eulerAngles.z);

        tempVec = tempVec + new Vector3(1,0,0);
        transform.eulerAngles = tempVec;

    }
}
