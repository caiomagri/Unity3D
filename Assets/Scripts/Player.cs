using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed;
	public float JumpForce;
	public bool isJumping;
	public bool doubleJumping;
	private Rigidbody2D rig;

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		rig = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		Jump();
	}

	void Move ()
	{
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		transform.position += movement * Time.deltaTime * Speed;

		if(Input.GetAxis("Horizontal") > 0f)
		{
			animator.SetBool("walk", true);
			transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}else if(Input.GetAxis("Horizontal") < 0f)
		{
			animator.SetBool("walk", true);
			transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}else
		{
				animator.SetBool("walk", false);
		}
		
	}

	void Jump()
	{
		if(Input.GetButtonDown("Jump")) 
		{
			if(!isJumping)
			{
				rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
				doubleJumping = true;
				animator.SetBool("jump", true);
			}
			else
			{
				if (doubleJumping) {
					rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
					doubleJumping = false;
				}
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.layer == 8)
		{
			isJumping = false;
			animator.SetBool("jump", false);
		}
	}
	private void OnCollisionExit2D(Collision2D collision) 
	{
		if (collision.gameObject.layer == 8)
		{
			isJumping = true;
		}
	}
}
