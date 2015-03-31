#pragma strict

var Effect : Transform;
var Effect2: Transform;

var duration = 2.0;
var flag = true;


function Update () {
	
	var hit : RaycastHit;
	var ray : Ray = Camera.main.ScreenPointToRay(Vector3(Screen.width*0.5, Screen.height*0.5, 0));
	if (Physics.Raycast (ray, hit, 100))
	{
		if (hit.collider.name.Equals("Plane")){
				var particleClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(particleClone.gameObject, duration);				
		}
		if (hit.collider.name.Equals("Cube1")){
			
			var particleClone2 = Instantiate(Effect2, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(particleClone2.gameObject, duration);					
		}								
		hit.transform.SendMessage("selected", flag, SendMessageOptions.DontRequireReceiver);
	}
}
