using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnerController : MonoBehaviour {
	public static LevelSpawnerController current;

	public GameObject ezWallsPrefab1;
	public GameObject ezWallsPrefab2;
	public GameObject hrdWallsPrefab1;
	public GameObject hrdWallsPrefab2;
	public int hrdMode = 4000;

	public float spawnDelta;
	float lastSpawn = 0;

	// Use this for initialization
	void Start () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		this.addWalls();
	}

	void addWalls(){
		if(spawnTime()){
			GameObject obj;
			if(LevelController.pointsNum > hrdMode){
				int random = (int) Mathf.Round(Random.Range(0.0f,3.0f));
				switch (random){
					case 0 :
						obj = GameObject.Instantiate(this.hrdWallsPrefab1);
						break;
					case 1 :
						obj = GameObject.Instantiate(this.ezWallsPrefab1);
						break;
					case 2 :
						obj = GameObject.Instantiate(this.ezWallsPrefab2);
						break;
					case 3 :
						obj = GameObject.Instantiate(this.hrdWallsPrefab2);
						break;
					default :
						obj = GameObject.Instantiate(this.ezWallsPrefab1);
						break;
				}
			} else {
				int random = (int) Mathf.Round(Random.Range(0.0f,1.0f));
				switch(random){
					case 0 :
						obj = GameObject.Instantiate(this.ezWallsPrefab1);
						break;
					case 1 :
						obj = GameObject.Instantiate(this.ezWallsPrefab2);
						break;
					default :
						obj = GameObject.Instantiate(this.ezWallsPrefab2);
						break;
				}
			}
			

            obj.transform.position = this.transform.position;
            
            lastSpawn = Time.time;
		}
	}
	

	bool spawnTime(){
		return Time.time - lastSpawn > spawnDelta;
	}
}
