    using UnityEngine;

public class ActorController : MonoBehaviour
{
    //public variables
    public PlayerInput pi;
    public GameObject model;
    public float walkSpeed = 1.0f;
    public bool lockPlanar = false;

    // private variables   
    private Animator anim;
    private Rigidbody rigid;
    private Vector3 movingVec;
    private Vector3 thrustVec;

    // Start is called before the first frame update
    void OnEnable()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            this.enabled = false;
            return;
        }

        pi = GetComponent<PlayerInput>()? GetComponent<PlayerInput>(): gameObject.AddComponent<PlayerInput>();
        model = anim.gameObject;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame, 60Hz
    void Update()
    {

        anim.SetFloat("forward", Mathf.Lerp(anim.GetFloat("forward"), pi.Dmag * ((pi.run) ? 2.0f : 1.0f), 0.05f));

        if (rigid.velocity.magnitude > 5.0f)
        {
            anim.SetTrigger("roll");
        }


        if (pi.jump)
        {
            anim.SetTrigger("jump");
            //thrustVec = new Vector3(0, 10.0f, 0);   //加在這裡可以無限跳躍，這是不對的，應該加在狀態機的Enter位置
        }

        if (lockPlanar == false)
        {
            if (pi.Dmag > 0.01f)
            {
                model.transform.forward = Vector3.Slerp(model.transform.forward, this.transform.TransformVector(pi.Dvec), 0.05f);
                //model.transform.forward = this.transform.TransformVector(pi.Dvec);
            }

            movingVec = pi.Dmag * model.transform.forward * walkSpeed * ((pi.run) ? 3.0f : 1.0f);
        }
    }

    // 50Hz
    void FixedUpdate()
    {
        rigid.velocity = new Vector3(movingVec.x, rigid.velocity.y, movingVec.z) + thrustVec;
        thrustVec = Vector3.zero;
    }

    public void OnJumpEnter()
    {
        lockPlanar = true;
        pi.inputEnable = false;  //以上兩件事可以鎖死角色移動
        //print("起跳囉~~~");
        thrustVec = new Vector3(0, 4.0f, 0);
    }

    public void OnJumpExit()
    {
        //print("降落囉~~~");
    }

    public void IsGround() {
        //print("is on ground~");
        anim.SetBool("isGround", true);
    }

    public void IsNotGround(){
        //print("is not on ground!!!!!!!!!!!!!!!");
        anim.SetBool("isGround", false);
    }

    public void OnFallingEnter() {
        //print("on falling enter!!!!!");
        lockPlanar = true;
        pi.inputEnable = false;
    }

    public void OnLocomotionEnter() {
        lockPlanar = false;
        pi.inputEnable = true;  //以上兩件事可以解鎖角色移動
        anim.ResetTrigger("roll ");
    }
}
