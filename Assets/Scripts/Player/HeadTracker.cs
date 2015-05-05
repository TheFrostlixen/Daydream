using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
public class HeadTracker : MonoBehaviour {
	// Use this for initialization
	void Start () {
		// Activate the gyroscope
		Input.gyro.enabled = true;
	}

	void Update () {
		Quaternion rotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		transform.localRotation = rotFix;
	}
	
}