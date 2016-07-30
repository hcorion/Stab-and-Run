using UnityEngine;
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
	public KeyCode attackMovementKey = KeyCode.V;
	private float JumpTime = 0f;
	private bool canJump = true;
	private Rigidbody2D player;
	private float jumpTime;
	public GameObject raycastPoint;
	public float jumpForce = 1f;
	public int positionState = 0;

	public Sprite left;
	public Sprite right;

	public Sprite mainSprite;
	private SpriteRenderer playerSprite;
	public GameObject sword;
	private SpriteRenderer sprite;
	public Sprite leftsprite;
	public Sprite rightsprite;
	public bool p = true;
	public Vector3 swordpos;
	void Start () {
		sprite = sword.GetComponent<SpriteRenderer>();
		player = gameObject.GetComponent<Rigidbody2D> ();
		playerSprite = gameObject.GetComponent<SpriteRenderer>();
		swordpos = sword.transform.localPosition;
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
		}

		if (Input.GetKey (JumpMovementKey) && canJump == true)
		{
			player.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			jumpTime += Time.deltaTime;
			//CanJump = false;
			//JumpTime  = MaxJumpTime;
		}
		if(Input.GetKey(rightMovementKey)){
			positionState = 1;
			playerSprite.sprite = right;
			//sprite.sprite = rightsprite;
			sword.transform.rotation = Quaternion.EulerAngles(0, 0, 0);
			sword.transform.localPosition = swordpos + new Vector3(0.1f, 0, 0);
			player.transform.position += Vector3.right * speed * Time.deltaTime;
			sword.SetActive(true);
		}
		else if(Input.GetKey(leftMovementKey)){
			positionState = 2;
			playerSprite.sprite = left;
			//sprite.sprite = leftsprite; 
			sword.transform.eulerAngles = new Vector3(0, 0, 180);
			sword.transform.localPosition = swordpos + new Vector3(-0.1f, 0, 0);
			player.transform.position += Vector3.left * speed * Time.deltaTime;
			sword.SetActive(true);
		}
		else 
		{
			positionState = 0;
			playerSprite.sprite = mainSprite;
			sword.SetActive(false);
		}
		if (Input.GetKey (attackMovementKey)) 
		{
			if (positionState == 1) {
				//sword.SetActive(true);
				sword.transform.localPosition += new Vector3(Time.deltaTime * 7, 0, 0);
			}
			if (positionState == 2) {
				
				sword.transform.localPosition -= new Vector3(Time.deltaTime * 7, 0, 0);
			}
		}
	}
}
