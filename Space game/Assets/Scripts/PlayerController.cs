using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb2D;

    // 0 gravity stuff


    /*
     kood võetud tutorialist  https://youtu.be/1Y_yupuTXmo 3:49 selgitused juhul kui unustan
      */
    private bool inZeroGravityZone = true;
    public float zeroGravMoveForce = 0f;
    public float normalMoveForce = 1f;
    public float jumpForce = 1;
    private float origGravityScale = 0f;
    private float moveForce = 0f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        origGravityScale = rb2D.gravityScale;

    }

  

    // 0 gravity osa algab siit
    private void FixedUpdate()
    {
        //Arvutamine + liikumine
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = inZeroGravityZone ? Input.GetAxisRaw("Vertical") * moveForce : 0f;

        rb2D.AddForce(new Vector2(h, v));
    }


    private void Update()
    {
        moveForce = inZeroGravityZone ? zeroGravMoveForce : normalMoveForce;
        rb2D.gravityScale = inZeroGravityZone ? 0f : origGravityScale;

        if (Input.GetKeyDown(KeyCode.Space) && !inZeroGravityZone)
        {
            rb2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
