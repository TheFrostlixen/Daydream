// HIGHLIGHT: Highlights an object upon selection(Done through RaycastDestroy)
// - By JC
using UnityEngine;

public class highlight : MonoBehaviour
{
	private bool isHighlighted = false;
	private int timer = 0;
	public int selectTime = 300;

	void Update()
	{
		if (isHighlighted == true)
		{
			// set color to show highlight
			GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f);

			// increment timer, destroy object if appropriate
			timer++;
			if (timer > selectTime)
			{
				Destroy(gameObject);
			}
		}
		
		else
		{
			// set color to show no highlight & reset timer
			GetComponent<Renderer>().material.color = new Color (1, 1, 1);
			timer = 0;
		}
		
		isHighlighted = false;
	}

	// See if object is being hovered over
	public void selected( bool flag )
	{
		isHighlighted = flag;
	}
}
