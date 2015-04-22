using UnityEngine;
using System.Collections;

public class CursorParticles : MonoBehaviour {
	public ParticleSystem cursor;
	public float duration = 0.5f;
	public Color colorOneAttention = new Color (255f, 204f, 153f);
	public Color colorTwoAttention = new Color (255f, 153f, 102f);
	public Color colorThreeAttention = new Color (255f, 102f, 51f);
	public Color colorFourAttention = new Color (255f, 51f, 0f);
	public Color colorFiveAttention = new Color (153f, 0f, 0f);
	public Color colorCurrent = Color.clear;
	Vector3 start = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f);
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);

		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.collider.name.Equals ("Terrain")) {
				// descretize brainwave values to set colors
				if(DisplayData.attention1 <= 20 && DisplayData.attention1 > 0){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					cursor.startColor = Color.Lerp(colorCurrent, colorOneAttention, lerp);
					colorCurrent = colorOneAttention;

				}
				if(DisplayData.attention1 <= 40 && DisplayData.attention1 > 20){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					cursor.startColor = Color.Lerp(colorCurrent, colorTwoAttention, lerp);
					colorCurrent = colorTwoAttention;
				}
				if(DisplayData.attention1 <=60  && DisplayData.attention1 > 20 ){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					cursor.startColor = Color.Lerp(colorCurrent, colorThreeAttention, lerp);
					colorCurrent = colorThreeAttention;
				}
				if(DisplayData.attention1 <= 80 && DisplayData.attention1 > 60){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					cursor.startColor = Color.Lerp(colorCurrent, colorFourAttention, lerp);
					colorCurrent = colorFourAttention;
				}
				if(DisplayData.attention1 <= 100 && DisplayData.attention1 > 80){		
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					cursor.startColor = Color.Lerp(colorCurrent, colorFiveAttention, lerp);
					colorCurrent = colorFiveAttention;
				}
				//Spawn particles
				ParticleSystem particleClone = (ParticleSystem)Instantiate (cursor, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(particleClone.gameObject, duration);
			}
		}
	}


}
