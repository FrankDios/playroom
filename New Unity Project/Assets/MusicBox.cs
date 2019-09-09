﻿using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    private bool pickUpAllowed;
    private bool grabbed;
    public float distance=2f;
    public Collider2D grab;
    public Collider2D hitbox;
    public Collider2D AoE;
    public float throwforce;
    public float charge;
    private float charging;
    private bool charged=false;
    void Start(){
        grabbed=false;
    }

    void Update () {

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)&&(grabbed==false)){
            PickUp();
        }
        else if (grabbed && Input.GetKeyDown(KeyCode.E)&&charged){
            Throw();
        }
        if(grabbed){
            this.transform.position=GameObject.Find("Lucy").transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            charging+=Time.deltaTime;
            Debug.Log(charging);
        }
        if (charging>=charge){
            charged=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name.Equals("Lucy")){
            pickUpAllowed = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.name.Equals("Lucy")){
            pickUpAllowed = false;
        }
    }
    private void PickUp(){
        grabbed=true;
        hitbox.enabled=false;
        Debug.Log("grabbed");
    }
    private void Throw(){
        grabbed=false;
        this.transform.position=GameObject.Find("Lucy").transform.position*throwforce;
    }
}