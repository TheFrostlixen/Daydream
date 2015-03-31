// HIGHLIGHT: Highlights an object upon selection(Done through RaycastDestroy)
// - By JC
#pragma strict

var isHighlighted : boolean = false;
var timer : int = 0;
var selectTime : int = 300;

function Update () {
	var val = 1.5;

	if (isHighlighted == true){
		GetComponent.<Renderer>().material.color = Color(val, val, val);
		//print(timer);
		timer ++;
		if (timer > selectTime){
			Destroy (gameObject); 
		}
	}
	
	else {
		GetComponent.<Renderer>().material.color = Color (1, 1, 1);
		timer = 0;
	}
	
 isHighlighted = false;
}

// See if object is being hovered over
function selected ( flag : boolean )
{
	isHighlighted = flag;	
}
