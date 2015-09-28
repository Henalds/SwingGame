using UnityEngine;
using System.Collections;

public class RopeShooting : MonoBehaviour {

	RaycastHit2D hit = new RaycastHit2D();

	bool ropeShot = false;

	GameObject hook;
	public GameObject currentHook;

	// Use this for initialization
	void Start () {
		hook = Resources.Load ("Hook") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
		                                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		//Debug.DrawRay (transform.position, mousePosition);

		// when mouse clicked on screen
		//TODO change to finger touch instead of mouse click once we get running on phone
		if (Input.GetMouseButtonDown (0) & ropeShot == false) {

			GameObject hookShot = Instantiate(hook) as GameObject;
			currentHook = GameObject.Find ("Hook(Clone)");
			hookShot.transform.position = transform.position;
			hookShot.GetComponent<Rigidbody2D>().velocity = mousePosition;

			Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);

			// shoot a raycast to were the player clicked
			hit = Physics2D.Raycast(playerPos, mousePosition);

		}

		if(currentHook.GetComponent<Rigidbody2D>().velocity == Vector2.zero){
			Debug.DrawLine (transform.position, currentHook.transform.position);
		}

	}
}
