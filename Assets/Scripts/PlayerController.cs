﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public float speed = 2.4f;
    public float jumpForce = 200;
    public LayerMask whatIsGround;
    //private Animator anim;
    public GameObject weaponPrefab;
    public Transform pointWeapon;
    public float weaponSpeed = 300;
 
    [HideInInspector]
    public bool lookingRight = true;
 
    private Rigidbody2D rb2d;
    public bool isGrounded = false;
    private bool jump = false;
 
    //[HideInInspector]
    private bool isAttacking = false;
 
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        //anim = GetComponent<Animator> ();
    }
     
    void Update () {
        inputCheck ();
        move ();
    }
 
    void inputCheck (){
 
        if (Input.GetButtonDown("Jump") && isGrounded){
            jump = true;
        }
 
        if (Input.GetButtonDown("Fire1") && !isAttacking){
            isAttacking = true;
        }
    }
 
    void move(){
         
        float horizontalForceButton = Input.GetAxis ("Horizontal");
        //anim.SetFloat ("speedHorizontal", Mathf.Abs(horizontalForceButton));
        rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
        //isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15f, whatIsGround);
        //anim.SetBool ("grounded", isGrounded);
 
        if ((horizontalForceButton > 0 && !lookingRight) || (horizontalForceButton < 0 && lookingRight))
            Flip ();
 
        if (jump) {
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
 
        if (isAttacking) {
            //anim.SetTrigger ("attacking");
 
            GameObject goWeapon = (GameObject) Instantiate (weaponPrefab, pointWeapon.position, Quaternion.identity);
 
            if (lookingRight){
                goWeapon.GetComponent<Rigidbody2D>().AddForce(Vector3.right * weaponSpeed);
            }else{
                goWeapon.GetComponent<Rigidbody2D>().AddForce(Vector3.left * weaponSpeed);
            }
         
        }
 
        isAttacking = false;
    }
 
    void Flip(){
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }
}