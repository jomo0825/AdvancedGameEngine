using UnityEngine;

public class ActorController : MonoBehaviour
{
    //public variables
    public PlayerInput pi;
    public GameObject model;
    public float walkSpeed = 1.0f;

    // private variables   
    private Animator anim;
    private Rigidbody rigid;
    private Vector3 movingVec;


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
        anim.SetFloat("forward", pi.Dmag);

        if (pi.Dmag > 0.01f)
        {
            model.transform.forward = this.transform.TransformVector(pi.Dvec);
        }

        movingVec = pi.Dmag * model.transform.forward * walkSpeed;
    }

    // 50Hz
    void FixedUpdate()
    {
        rigid.velocity = movingVec;
    }
}
