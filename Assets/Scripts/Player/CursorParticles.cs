using UnityEngine;
using System.Collections;

public class CursorParticles : MonoBehaviour {
	public ParticleSystem Attention;
	public ParticleSystem Meditation;
	public float duration = 0.5f;
	public Color colorOneAttention = new Color (255f, 204f, 153f);
	public Color colorTwoAttention = new Color (255f, 153f, 102f);
	public Color colorThreeAttention = new Color (255f, 102f, 51f);
	public Color colorFourAttention = new Color (255f, 51f, 0f);
	public Color colorFiveAttention = new Color (153f, 0f, 0f);
	public Color colorOneMeditation = new Color (255f, 204f, 153f);
	public Color colorTwoMeditation = new Color (255f, 153f, 102f);
	public Color colorThreeMeditation = new Color (255f, 102f, 51f);
	public Color colorFourMeditation = new Color (255f, 51f, 0f);
	public Color colorFiveMeditation = new Color (153f, 0f, 0f);
	public Color colorCurrentAttention = Color.clear;
	public Color colorCurrentMeditation = Color.clear;
	Vector3 start = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f);
	
	// Use this for initialization
	void Start () {
		Attention.enableEmission = false;
		Meditation.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(start);
		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.collider.name.Equals ("Terrain")) {
				Attention.enableEmission = true;
				Meditation.enableEmission = true;
				// For attention: descretize brainwave values to set colors
				if(DisplayData.attention1 <= 20 && DisplayData.attention1 >= 0){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Attention.startColor = Color.Lerp(colorCurrentAttention, colorOneAttention, lerp);
					colorCurrentAttention = colorOneAttention;
					Attention.emissionRate = 0.5f;
				}
				if(DisplayData.attention1 <= 40 && DisplayData.attention1 > 20){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Attention.startColor = Color.Lerp(colorCurrentAttention, colorTwoAttention, lerp);
					colorCurrentAttention = colorTwoAttention;
					Attention.emissionRate = 3f;
				}
				if(DisplayData.attention1 <=60  && DisplayData.attention1 > 40 ){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Attention.startColor = Color.Lerp(colorCurrentAttention, colorThreeAttention, lerp);
					colorCurrentAttention = colorThreeAttention;
					Attention.emissionRate = 7f;
				}
				if(DisplayData.attention1 <= 80 && DisplayData.attention1 > 60){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Attention.startColor = Color.Lerp(colorCurrentAttention, colorFourAttention, lerp);
					colorCurrentAttention = colorFourAttention;
					Attention.emissionRate = 13f;
				}
				if(DisplayData.attention1 <= 100 && DisplayData.attention1 > 80){		
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Attention.startColor = Color.Lerp(colorCurrentAttention, colorFiveAttention, lerp);
					colorCurrentAttention = colorFiveAttention;
					Attention.emissionRate = 20f;
				}

				// For meditation: descretize brainwave values to set colors
				if(DisplayData.meditation1 <= 20 && DisplayData.meditation1 >= 0){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Meditation.startColor = Color.Lerp(colorCurrentMeditation, colorOneMeditation, lerp);
					colorCurrentMeditation = colorOneMeditation;
					Meditation.emissionRate = 0.1f;
					
				}
				if(DisplayData.meditation1 <= 40 && DisplayData.meditation1 > 20){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Meditation.startColor = Color.Lerp(colorCurrentMeditation, colorTwoMeditation, lerp);
					colorCurrentAttention = colorTwoMeditation;
					Meditation.emissionRate = 3f;
				}
				if(DisplayData.meditation1 <=60  && DisplayData.meditation1 > 40 ){
					
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Meditation.startColor = Color.Lerp(colorCurrentMeditation, colorThreeMeditation, lerp);
					colorCurrentMeditation = colorThreeMeditation;
					Meditation.emissionRate = 7f;
				}
				if(DisplayData.meditation1 <= 80 && DisplayData.meditation1 > 60){
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Meditation.startColor = Color.Lerp(colorCurrentMeditation, colorFourMeditation, lerp);
					colorCurrentMeditation = colorFourMeditation;
					Meditation.emissionRate = 13f;
				}
				if(DisplayData.meditation1 <= 100 && DisplayData.meditation1 > 80){		
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					Meditation.startColor = Color.Lerp(colorCurrentMeditation, colorFiveMeditation, lerp);
					colorCurrentMeditation = colorFiveMeditation;
					Meditation.emissionRate = 20f;
				}

				//Spawn particles
				ParticleSystem particleCloneA = (ParticleSystem)Instantiate (Attention, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(particleCloneA.gameObject, duration);
				ParticleSystem particleCloneM = (ParticleSystem)Instantiate (Meditation, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(particleCloneM.gameObject, duration);
			}
		}
	}


}
