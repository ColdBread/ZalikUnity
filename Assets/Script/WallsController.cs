using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour {
	public Rigidbody2D myBody;

	public float speed;

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vel = myBody.velocity;
		vel.y = speed;
		myBody.velocity = vel;
	}

	public void Destroy(){
		
		Destroy(this.gameObject);
	}
}
