using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByRigidBody : MonoBehaviour
{
    [SerializeField]
    private float SpeedFactor = 10f;

    [SerializeField]
    private float force = 10f;

    private Rigidbody2D Rb;

    private Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Rb.velocity = new Vector2(horizontalInput * SpeedFactor, Rb.velocity.y);

        if (horizontalInput != 0)
        {
            // play Bounce but start at a quarter of the way though
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (Rb.velocity.y == 0f)
            {
                Rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            }
        }
    }
}
