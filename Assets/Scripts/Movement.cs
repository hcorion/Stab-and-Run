using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed = 1f;
	public float MaxJumpTime = 10000f;
	public float JumpForce;
	public float moveVertical;
	public float moveHorizontal;
	private float JumpTime = 0f;
	private bool CanJump = false;
	public Rigidbody2D player;
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (!CanJump)
			JumpTime  -= Time.deltaTime;
		Debug.Log (JumpTime);
		if (JumpTime <= 0)
		{
			CanJump = true;
			JumpTime  = MaxJumpTime;
		}
	}
	void FixedUpdate () {
		/*moveVertical = Input.GetAxis ("Vertical");
		moveHorizontal = Input.GetAxis ("Horizontal");
		player.velocity = new Vector2 (moveVertical * speed, player.velocity.y);
		*/
		if (Input.GetKey (KeyCode.W) && CanJump == true)
		{
			player.AddForce (new Vector2 (0, 1), ForceMode2D.Impulse);
			CanJump = false;
			JumpTime  = MaxJumpTime;
		}
		if(Input.GetKey(KeyCode.D)){
			player.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			player.transform.position += Vector3.left * speed * Time.deltaTime;
		}
}
}
