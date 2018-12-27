using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfiniteBridge : MonoBehaviour {

	public GameObject[] tiles;
	public GameObject[] obstacles;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLenght = 12.0f;
	private int amnTilesOnScreen = 7;
	private bool val;

	// Use this for initialization
	void Start () {

		val = false;

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;


		for (int i = 0; i < amnTilesOnScreen; i++) {
			spawnTiles ();
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLenght)) {
			spawnTiles ();
		}
	}


	private void spawnTiles(int prefabIndex = -1){
		GameObject go;
		go = Instantiate (tiles [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		if(val)
			createObstacle(go.transform.position);
		val=!val;
		spawnZ += tileLenght;
	}

	private void createObstacle(Vector3 tempPosition){
		GameObject obs = Instantiate (obstacles [0]) as GameObject;
		obs.transform.SetParent (transform);
		tempPosition.x = Random.Range (-2,2);
		obs.transform.position = tempPosition;
	}
}
