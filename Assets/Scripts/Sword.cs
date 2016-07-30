using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public GameManager manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && col.gameObject != transform.root) {
			manager.kill(col.gameObject);		
			}
	}
}
