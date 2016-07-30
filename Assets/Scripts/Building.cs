using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	public GameObject tile;
	public float counter = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			Instantiate (tile, new Vector2 (counter, 0), Quaternion.identity);
			counter += 0.7f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
