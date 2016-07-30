using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && col.gameObject != transform.root) {
			Destroy (col.gameObject);
		}
	}
}
