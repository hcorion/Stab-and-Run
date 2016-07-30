using UnityEngine;
using System.Collections;

public class winTriggers : MonoBehaviour {

	private bool isPlayerSet = false;
	private GameObject myPlayer;
	public GameObject playerStartPoint;
	// Use this for initialization
	void Start () {
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (!isPlayerSet)
			{
				myPlayer = col.gameObject;
			}
			else if (col.gameObject != myPlayer)
			{
				//The opposing player won!
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
