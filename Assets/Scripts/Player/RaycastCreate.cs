using UnityEngine;
using System.Collections;

public class RaycastCreate : MonoBehaviour {
	public float timerBase = 0.5f;

	public Transform FlowerLow;
	public Transform FlowerMid;
	public Transform FlowerHigh;

	public int resizeThreshold = 70;
	public int recolorThreshold = 70;
	public int createThreshold = 70;

	Vector3 start = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f);
	float Timer = 0.5f;

	public AudioClip lowCreate;
	public AudioClip midCreate;
	public AudioClip highCreate;
	public AudioSource audio;
	
	void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);
		
		// wait a short amount of time so 91929129 flowers aren't created
		Timer -= Time.deltaTime;
		
		// check if ray has collided with something
		if (Physics.Raycast (ray, out hit, 100))
		{
			//access wave values through displayData
			if (hit.collider.name.Equals ("Terrain")) 
			{
				if(DisplayData.attention1 > createThreshold && Timer < 0)
				{
					// create flowers, each rotated a bit different based on meditation
					if(DisplayData.meditation1 < 30)
					{
						Instantiate (FlowerLow, hit.point,Quaternion.Euler(270, ( Random.Range(0.0f,360.0f) ), 0));
						audio.PlayOneShot(lowCreate,0.7f);
					}
					else if(DisplayData.meditation1 < 60 && DisplayData.meditation1 >= 30 )
					{
						Instantiate( FlowerMid, hit.point, Quaternion.Euler(270, ( Random.Range(0.0f,360.0f) ), 0) );
						audio.PlayOneShot(midCreate,0.7f);
					}
					else
					{
						Instantiate (FlowerHigh, hit.point, Quaternion.Euler(270, ( Random.Range(0.0f,360.0f) ), 0));
						audio.PlayOneShot(highCreate,0.7f);
					}
					Timer = timerBase;
				}
			}
			else // assume the raycast hit a flower
			{
				/*
				// resize
				if (DisplayData.attention1 > resizeThreshold && Timer < 0)
				{
					// do math & resize
					float scale = DisplayData.attention1 / 10.0f; // size range: 1/10 to 10x
					hit.collider.gameObject.transform.localScale = new Vector3( scale, scale, scale );
					// TODO make sure it doesn't clip through the ground...
					
					// reset timer
					Timer = timerBase;
				}
				*/
				// recolor
				if (DisplayData.meditation1 > recolorThreshold && Timer < 0)
				{
					float h, s, v;

					// get HSV values for current flower color
					FlowerShader.ColorToHSV( hit.collider.gameObject.GetComponent<Renderer>().material.color, out h, out s, out v );

					// adjust hue based on meditation
					h = DisplayData.meditation1 * 3.6f; // hue: 0-360

					// set the object's adjusted color
					hit.collider.gameObject.GetComponent<Renderer>().material.color = FlowerShader.ColorFromHSV(h, s, v, 1.0f);

					// reset timer
					Timer = timerBase;
				}
			}
		}
	}
}
