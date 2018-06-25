using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider)
    {
        
        HeroController hero = collider.GetComponent<HeroController>();
        
        if (hero != null)
        {
            LevelController.current.endGame();
            Debug.Log("minus jizn");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
