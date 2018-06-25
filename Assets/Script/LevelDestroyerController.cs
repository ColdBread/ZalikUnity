using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyerController : MonoBehaviour {

	

	void OnTriggerEnter2D(Collider2D collider)
    {
        
        WallsController wall = collider.GetComponent<WallsController>();
        
        if (wall != null)
        {
            LevelController.addPointForWalls();
            wall.Destroy();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
