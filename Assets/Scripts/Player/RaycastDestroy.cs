// RAYCASTDESTROY: Used to set cursor in the middle of the screen and destroy based on brain readings
using UnityEngine;
using System.Collections;

public class RaycastDestroy : MonoBehaviour {
	public Transform Effect;
	public Transform Effect2;
	
	bool flag= true;
	Vector3 start = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f);
	
	
	void  Update (){
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);

		// check if ray has collided with something
		if (Physics.Raycast (ray, out hit, 100))
		{
			if (hit.collider.name.Equals("Plane")){
				
				Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
				
			}

			// Both cubes use focus(attention) levels for destruction
			if (hit.collider.name.Equals("Cube1")){
				
				Instantiate(Effect2, hit.point, Quaternion.LookRotation(hit.normal));

				//access wave values through displayData
				if(DisplayData.attention1 > 90 )
					Destroy (hit.transform.gameObject);
			}

			if (hit.collider.name.Equals("Cube2")){
				
				Instantiate(Effect2, hit.point, Quaternion.LookRotation(hit.normal));
				
				//access wave values through displayData
				if(DisplayData.attention1 > 90 )
					Destroy (hit.transform.gameObject);
			}

			// Both capsules use relaxation(meditation) for destruction
			if (hit.collider.name.Equals("Capsule1")){
				
				Instantiate(Effect2, hit.point, Quaternion.LookRotation(hit.normal));
				
				//access wave values through displayData
				if(DisplayData.meditation1 > 90 )
					Destroy (hit.transform.gameObject);
			}

			if (hit.collider.name.Equals("Capsule2")){
				
				Instantiate(Effect2, hit.point, Quaternion.LookRotation(hit.normal));
				
				//access wave values through displayData
				if(DisplayData.meditation1 > 90 )
					Destroy (hit.transform.gameObject);
			}

			// send message to destroyed object
			hit.transform.SendMessage("selected", flag, SendMessageOptions.DontRequireReceiver);
		}
	}
	
}