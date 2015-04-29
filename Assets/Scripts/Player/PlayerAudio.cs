using System;
using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour
{
	public AudioClip audioFocus;
	public AudioClip audioMeditation;

	AudioSource sourceFocus;
	AudioSource sourceMeditation;
	TGCConnectionController controller;
	
	int attention1;
	int meditation1;
	float delta;

	void Start()
	{
		// set up BCI controller & events
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdateDeltaEvent += OnUpdateDelta;

		// set up focus audio source
		sourceFocus.loop = true;
		sourceFocus.playOnAwake = false;
		sourceFocus.spatialBlend = 0.0f; // 2d sound
		sourceFocus.clip = audioFocus;

		// set up meditation audio source
		sourceMeditation.loop = true;
		sourceMeditation.playOnAwake = false;
		sourceMeditation.spatialBlend = 0.0f; // 2d sound
		sourceMeditation.clip = audioMeditation;
	}

	void Update()
	{
		// attention sound
		if (attention1 > 50) // arbitrary lower bound to play audio
		{
			sourceFocus.volume = attention1 / 100.0f;
			sourceFocus.Play();
		}
		else
			sourceFocus.Stop();

		// meditation sound
		if (meditation1 > 50) // again, arbitrary lower bound
		{
			sourceMeditation.volume = meditation1 / 100.0f;
			sourceMeditation.Play();
		}
		else
			sourceMeditation.Stop();
	}
	
	void OnUpdateAttention(int value)
	{
		attention1 = value;
	}

	void OnUpdateMeditation(int value)
	{
		meditation1 = value;
	}

	void OnUpdateDelta(float value)
	{
		delta = value;
	}
}
