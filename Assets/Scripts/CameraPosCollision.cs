using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosCollision : MonoBehaviour
{

    private GameObject cameraHandle;

    // Start is called before the first frame update
    void Start()
    {
        cameraHandle = transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast( cameraHandle.transform.position, (transform.position - cameraHandle.transform.position), 
            out hit, 3.5f))
        {
            //print(hit.collider.name);
            transform.position = hit.point;
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, -3.5f);
        }
    }
}

