using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /*
     kood võetud tutorialist  https://youtu.be/1Y_yupuTXmo 3:49 selgitused juhul kui unustan
      */


    public float zeroGravMoveForce = 0f;
    public float normalMoveForce = 0f;
    private float moveForce = 0f;
    private Rigidbody2D rb2D;

    // Kogu maailmas 0 gravity hetkel
    private bool inZeroGravityZone = true;
    private float origGravityScale = 0f;
    public float jumpForce = 0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        origGravityScale = rb2D.gravityScale;

    }
    private void FixedUpdate()
    {
        //Arvutamine + liikumine
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = inZeroGravityZone ? Input.GetAxisRaw("Vertical") * moveForce : 0f;

        rb2D.AddForce(new Vector2 (h, v));
    }
    private void Update()
    {
        moveForce = inZeroGravityZone ? zeroGravMoveForce : normalMoveForce;
        rb2D.gravityScale = inZeroGravityZone ? 0f : origGravityScale;

        if(Input.GetKeyDown(KeyCode.Space) && !inZeroGravityZone) {
            rb2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
