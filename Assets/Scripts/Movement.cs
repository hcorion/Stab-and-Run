﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 1f;
	public float MaxJumpTime = 1f;
	//public float JumpForce;
	//public float moveVertical;
	//public float moveHorizontal;
	public KeyCode leftMovementKey = KeyCode.A;
	public KeyCode rightMovementKey = KeyCode.D;
	public KeyCode JumpMovementKey = KeyCode.W;
	private float JumpTime = 0f;
	private bool canJump = true;
	private Rigidbody2D player;
	private float jumpTime;
	public GameObject raycastPoint;
	public float jumpForce = 1f;
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (jumpTime > MaxJumpTime)
		{
			canJump = false;
			jumpTime = 0;
		}
	}
	void FixedUpdate () {
		/*moveVertical = Input.GetAxis ("Vertical");
		moveHorizontal = Input.GetAxis ("Horizontal");
		player.velocity = new Vector2 (moveVertical * speed, player.velocity.y);
		*/
		if (canJump == false)
		{
			//RaycastHit2D
			RaycastHit2D hit = Physics2D.Raycast(raycastPoint.transform.position, Vector2.down, .1f);
			if (hit.collider != null)
			{
				Debug.Log("Something or other is " + hit.collider.name);
				canJump = true;
				jumpTime = 0;
			}
		{

		}
		}
		if (Input.GetKey (JumpMovementKey) && canJump == true)
		{
			player.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			jumpTime += Time.deltaTime;
			//CanJump = false;
			//JumpTime  = MaxJumpTime;
		}
		if(Input.GetKey(rightMovementKey)){
			player.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(leftMovementKey)){
			player.transform.position += Vector3.left * speed * Time.deltaTime;
		}
}
}
