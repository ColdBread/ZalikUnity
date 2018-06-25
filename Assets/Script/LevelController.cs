using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
    public static int pointsNum = 0;

    

    // Use this for initialization
    void Start () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		addPointForTime();
		ScoreController.current.UpdateScore(pointsNum/10);
		
	}

	public static void addPointForWalls(){
		pointsNum+=100;
	}

	void addPointForTime(){
		pointsNum++;
	}

	LocalStats getStats(){
		LocalStats stats = new LocalStats
        {
            score = pointsNum
        };
        return stats;
	}

	

	public void endGame(){
		
		LocalStats stats = this.getStats();
		
		stats.save();
		
		SceneManager.LoadScene("MainMenu");
		pointsNum = 0;

		
        
        
	}

	void destroyObjects(){
		Destroy(HeroController.current.gameObject);
		Destroy(LevelSpawnerController.current.gameObject);
		
	}
}
