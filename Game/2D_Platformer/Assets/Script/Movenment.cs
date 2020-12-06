using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movenment : MonoBehaviour{
    //For running
    public float movementElo;
    public Rigidbody2D velo;
    float leftRight;

    //For jumping
    public float jumpF = 20f;
    public Transform jfunction;
    public LayerMask groundLayers;

    private void Update()
    {
        leftRight = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("jump") && onGround())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(leftRight * movementElo, velo.velocity.y);

        velo.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(velo.velocity.x, jumpF);

        velo.velocity = movement;
    }

    public bool onGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(jfunction.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

}
