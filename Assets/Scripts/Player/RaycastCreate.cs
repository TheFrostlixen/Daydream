//Create an object based on 

using UnityEngine;
using System.Collections;

public class RaycastCreate : MonoBehaviour {
	public Transform FlowerLow;
	public Transform FlowerHigh;
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
				if(DisplayData.attention1 > 65 && Timer < 0){
					// create flowers, each rotated a bit different based on meditation
					if(DisplayData.meditation1 < 50){
						Instantiate (FlowerLow, hit.point, Quaternion.Euler(0,(Random.Range(0.0f,360.0f)),0));
					}
					else{
						Instantiate (FlowerHigh, hit.point, Quaternion.Euler(0,(Random.Range(0.0f,360.0f)),0));
					}
					Timer = 0.5f; //reset timer
				}
			}
		}
	}
}
