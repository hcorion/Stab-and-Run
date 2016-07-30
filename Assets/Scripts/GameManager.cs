using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;
	public GameObject scene;
	public GameObject startingScene;
	private Transform targetSceneTransform;
	public GameObject camera;
	private int index = 0;

	public Text text1;
	public Text text2;
	public GameObject player1;
	public GameObject player2;
	public int p1string;
	public int p2string;
	private bool isFirst = true;

	// Use this for initialization
	void Awake()
	{
		targetSceneTransform = startingScene.transform;
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		text1.text = "Score: " + p1string;
		text2.text = "Score: " + p2string;
	}

	public void kill(GameObject obj)
	{

		index++;
		camera.transform.position += new Vector3(23.73f, 0, 0);
		//23.73
		GameObject alive = null;
		foreach(GameObject noob in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (noob != obj)
			{
				alive = noob;
			}
		}
		if (isFirst)
		{
			isFirst = false;
			player2 = obj;
			player1 = alive;
		}
		if(player1 == obj)
		{
			p2string++;
		}
		else if(player2 == obj)
		{
			p1string++;
		}
		door2.SetActive(false);
		GameObject newScene = (GameObject)GameObject.Instantiate(scene, startingScene.transform.position + new Vector3(23.73f * index, 0, 0), Quaternion.identity);
		SceneScript sceneScript = newScene.GetComponent<SceneScript>();
		alive.transform.position = sceneScript.alivePlayerStart.transform.position;
		GameObject player = obj;
		sceneScript.door1.SetActive(false);
		obj.SetActive(false);
		obj.transform.position = sceneScript.playerStartPoint[Random.Range(0, sceneScript.playerStartPoint.Length)].transform.position;
		//obj.transform.position = Random.Range(0, scene)
		obj.SetActive(true);
	}
}
