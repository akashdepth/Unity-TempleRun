using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private float score;
	public Text scoreText;
	private bool isDeath;
	public DeathMenu deathMenu;

	// Use this for initialization
	void Start () {
		isDeath = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isDeath) {
			return;
		}

		score += Time.deltaTime;
		scoreText.text = ((int)score).ToString ();
	}

	public void onDeath(){
		isDeath = true;
		deathMenu.toggleEndMenu (score);
	}
}
