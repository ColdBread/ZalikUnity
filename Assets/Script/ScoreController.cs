using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text score;
	public Text highScore;
	public static ScoreController current;

	// Use this for initialization
	void Start () {
		current = this;
		highScore.text = GeneralStats.fromStorage().highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(int score){
		this.score.text = score.ToString();
	}
}
