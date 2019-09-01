﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad;
    public Rigidbody2D rb;
    //public Animator animator;
    Vector2 mvmt;
    public float dashVel;
    private float dashTime;
    public float dashDur;
    public float coolDown;
    private float vel;
    private float cdTime;
    private Transform t;
    void Start()
    {
        t=transform;
    }
    void Update()
    {
        /* 
        anim.SetFloat("Horizontal",mvmt.x);
        anim.SetFloat("Vertical",mvmt.y);
        anim.SetFloat("vel",mvmt.sqrMagnitude);
        */
        mvmt.Set(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        t.eulerAngles=new Vector3(0.0f,0.0f,0.0f);
    }
    void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time>cdTime){
            if(dashTime<=0){
                dashTime=dashDur;
                vel=velocidad;
            }else{
                dashTime-=Time.deltaTime;
                vel=dashVel;
                cdTime=coolDown+Time.time;
            }
        }else{
            vel=velocidad;
        }
        //le agrege este if (el de abajo) pero no lo he probado si te da problemas quitalo junto con su else  -Dios
        if ((Input.GetAxisRaw("Horizontal")!=0.0f)&&((Input.GetAxisRaw("Vertical"))!=0.0f)){
            vel=velocidad/2;
        }else{
            vel=velocidad;
        }
        rb.MovePosition(rb.position + mvmt * vel * Time.fixedDeltaTime);
    }
}
