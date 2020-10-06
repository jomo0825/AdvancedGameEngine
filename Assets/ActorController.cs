using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public PlayerInput pi;
    public Animator anim;


    // Start is called before the first frame update
    void OnEnable()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            this.enabled = false;
            return;
        }

        //pi = GetComponent<PlayerInput>();
        //if (pi == null)
        //{
        //    pi = gameObject.AddComponent<PlayerInput>();
        //}

        pi = GetComponent<PlayerInput>()? GetComponent<PlayerInput>(): gameObject.AddComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("forward", pi.Dmag);
    }
}
