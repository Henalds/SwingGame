using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Movement
	public float moveSpeed;
	public float jumpHeight;
	bool isJumping;

	//Lives
	public int lives;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Dont jump if already in the air
		if(GetComponent<Rigidbody2D>().velocity.y == 0){
			isJumping = false;
		}

		// Jump
		if(Input.GetKeyDown(KeyCode.Space) & !isJumping){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			isJumping = true;
		}

		//Move left and right
		else if(Input.GetKey(KeyCode.D) & !isJumping){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		else if(Input.GetKey(KeyCode.A) & !isJumping){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		// Stop sliding
		if(Input.GetKeyUp(KeyCode.D) & !isJumping){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(Input.GetKeyUp(KeyCode.A) & !isJumping){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
