// MOVEMENT: Takes keyboard input from the user(WASD or arrows) and moves the player
// By JC - Currently not used
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	void FixedUpdate ()
	{
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");

				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
				
		}
}
