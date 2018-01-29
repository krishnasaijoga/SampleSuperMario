﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_move_prot : MonoBehaviour {
	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
    public bool isGrounded=false;
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void PlayerMove() {
		//THIS FUNCTION CONTAINS
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)  // DEFAULT KEY FOR JUMP IS SPACE KEY
        {
            Jump();
        }
		//ANIMATIONS

		//PLAYER DIRECTION
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}
		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

	void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x = localScale.x * (-1);
        transform.localScale = localScale;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with "+collision.collider.name);
        if (collision.collider.tag == "ground" || collision.collider.tag == "brick")
            isGrounded = true;
    }
}
