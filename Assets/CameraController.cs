using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerInput pi;

    public GameObject cameraHandle;
    public GameObject playerHandle;
    public GameObject model;

    private Vector3 tempVec;

    // Start is called before the first frame update
    void Start()
    {
        cameraHandle = transform.parent.gameObject;
        playerHandle = cameraHandle.transform.parent.gameObject;
        model = playerHandle.GetComponent<ActorController>().model;

        pi = playerHandle.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempModelAngles = model.transform.eulerAngles;

        playerHandle.transform.Rotate(Vector3.up, pi.Jright);
        //cameraHandle.transform.Rotate(Vector3.right, -pi.Jup);

        tempVec = tempVec + new Vector3(-pi.Jup, 0, 0);
        tempVec.x = Mathf.Clamp(tempVec.x, -30 , 60);
        cameraHandle.transform.localEulerAngles = tempVec;

        model.transform.eulerAngles = tempModelAngles;
    }
}


