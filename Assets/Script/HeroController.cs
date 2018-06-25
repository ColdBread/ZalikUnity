using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	public Rigidbody2D myBody;
	public float speed;
	public SpriteRenderer sr;
	public Animator animator;
	bool isGroundedLeft = false;
	bool isGroundedRight = false;
	public static HeroController current;
	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
		sr = this.GetComponent<SpriteRenderer>();
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded())
			Jump();
	}

	void Jump(){
		/*if(Input.touchCount > 0){
		Touch touch = Input.GetTouch(0);
		if(touch.phase == TouchPhase.Began){
			Vector2 vel = myBody.velocity;
			vel.x = speed;
			myBody.velocity = vel;
		}
		}*/
		if(Input.GetMouseButton(0)){
			if(isGroundedLeft){
				Vector2 vel = myBody.velocity;
				vel.x = speed;
				myBody.velocity = vel;
				animator.SetBool("Jump",true);
			} else if (isGroundedRight){
				Vector2 vel = myBody.velocity;
				vel.x = -1*speed;
				myBody.velocity = vel;
				animator.SetBool("Jump",true);
			}
		}
	}

	bool isGrounded(){
		Vector3 right_from = transform.position + Vector3.left * 0.6f;
        Vector3 right_to = transform.position + Vector3.right * 0.8f;
		Vector3 left_from = transform.position + Vector3.right * 0.6f;
        Vector3 left_to = transform.position + Vector3.left * 0.8f;

        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(left_from, left_to, layer_id);
        if (hit){
			isGroundedLeft = true;
			isGroundedRight = false;
			sr.flipX = false;
			animator.SetBool("Jump",false);
		}
		RaycastHit2D hit2 = Physics2D.Linecast(right_from, right_to, layer_id);
		if(hit2){
			isGroundedRight = true;
			isGroundedLeft = false;
			sr.flipX = true;
			animator.SetBool("Jump",false);
		}

		Debug.DrawLine(left_from, left_to, Color.red);
		Debug.DrawLine(right_from, right_to, Color.red);

		return true;
	}
}
