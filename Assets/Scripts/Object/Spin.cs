//SPIN: Used to slowly spin the destroyable objects.

using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 15f;
	
	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}