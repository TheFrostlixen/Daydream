using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour
{
	public float LoadingTimer = 10;
	
	void Update()
	{
		LoadingTimer -= Time.deltaTime;

		if (LoadingTimer < 0)
		{
			// load main game
			Application.LoadLevel(1);
		}
	}
}
