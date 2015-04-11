//Create an object based on 

using UnityEngine;
using System.Collections;

public class RaycastCreate : MonoBehaviour {
	public Transform Flower;
	public float Timer=0.5f;
	Vector3 start = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f);

	void  Update (){
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);

		// wait a short amount of time so 91929129 flowers aren't created
		Timer-=Time.deltaTime;

		// check if ray has collided with something
		if (Physics.Raycast (ray, out hit, 100)) {
			//access wave values through displayData
			if (hit.collider.name.Equals ("Terrain")) {
				if(DisplayData.attention1 > 70 && Timer < 0){
					// create flower, each rotated a bit different
					Instantiate (Flower, hit.point, Quaternion.Euler(0,(Random.Range(0.0f,360.0f)),0));
					Timer = 0.5f; //reset timer
				}
			}
		}
	}
}
