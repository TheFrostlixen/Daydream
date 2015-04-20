using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float speed = 2.0f;
	public float WaitTime = 0.5f;

	private float Timer = 0;
	private Vector3 start = new Vector3( Screen.width*0.5f, Screen.height*0.5f, 0.0f );
	
	void FixedUpdate()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);

		// wait a short amount of time so player doesn't randomly sprint away
		Timer -= Time.deltaTime;

		// TODO adjust speed based on focus


		// check if ray has NOT collided with something
		if ( !Physics.Raycast(ray, out hit, 100) )
		{
			//Vector3 cam = (Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
			GameObject.FindWithTag("Player").transform.Translate( new Vector3( (Camera.main.transform.forward.x), 0, (Camera.main.transform.forward.z) ) * Time.deltaTime * speed);
		}
		else // player started looking at something, better stop
		{
			Timer = WaitTime;
		}
	}
}
