using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("=== 請填入以下參數 ===")]
    public GameObject cameraHandle;

    [Header("=== 以下部分程式碼會自動抓取 ===")]
    //public KeyboardInput pi;
    public PlayerInput pi;
    public GameObject playerHandle;
    public GameObject model;
    public GameObject cameraPos;

    private Vector3 tempVec;

    // Start is called before the first frame update
    void Start()
    {
        //cameraHandle = transform.parent.gameObject;
        playerHandle = cameraHandle.transform.parent.gameObject;
        model = playerHandle.GetComponent<ActorController>().model;

        pi = playerHandle.GetComponent<PlayerInput>();

        cameraPos = cameraHandle.transform.GetChild(0).gameObject;
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

    void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPos.transform.position, 0.1f);
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, cameraPos.transform.eulerAngles, 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraPos.transform.rotation, 0.1f);
    }
}


