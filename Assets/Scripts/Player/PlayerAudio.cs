using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
	public AudioClip audioFocus;
	public AudioClip audioMeditation;

<<<<<<< HEAD
	AudioSource sourceFocus;
	AudioSource sourceMeditation;

	void Start()
	{
=======
	public AudioSource sourceFocus;
	public AudioSource sourceMeditation;
	TGCConnectionController controller;
	
	int attention1;
	int meditation1;

	void Start()
	{
		// set up BCI controller & events
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;

>>>>>>> origin/master
		// set up focus audio source
		sourceFocus = new AudioSource();
		sourceFocus.loop = true;
		sourceFocus.playOnAwake = false;
		sourceFocus.spatialBlend = 0.0f; // 2d sound
		sourceFocus.clip = audioFocus;

		sourceFocus.Play();

		// set up meditation audio source
		sourceMeditation = new AudioSource();
		sourceMeditation.loop = true;
		sourceMeditation.playOnAwake = false;
		sourceMeditation.spatialBlend = 0.0f; // 2d sound
		sourceMeditation.clip = audioMeditation;

		sourceMeditation.Play();
	}

	void FixedUpdate()
	{
		// attention sound
<<<<<<< HEAD
		sourceFocus.volume = DisplayData.attention1 / 100.0f;

		// meditation sound
		sourceMeditation.volume = DisplayData.meditation1 /100.0f;
=======
		sourceFocus.volume = attention1 / 100.0f;
		sourceFocus.Play();

		// meditation sound
		sourceMeditation.volume = meditation1 /100.0f;
		sourceMeditation.Play();
	}
	
	void OnUpdateAttention(int value)
	{
		attention1 = value;
	}

	void OnUpdateMeditation(int value)
	{
		meditation1 = value;
>>>>>>> origin/master
	}
}
