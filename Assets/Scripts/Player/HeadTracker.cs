using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
public class HeadTracker : MonoBehaviour {
	// Use this for initialization
	public Transform Parent;
	void Start () {
		// Activate the gyroscope
		Input.gyro.enabled = true;

		GameObject camParent = new GameObject ("CamParent");//This stuff makes the player move not work
		camParent.transform.position = transform.position;
		transform.parent = camParent.transform;
		camParent.transform.Rotate (Vector3.right, 90);

		Quaternion rotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
	}

	void Update () {
		Quaternion rotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		transform.localRotation = rotFix;
	}
	
}