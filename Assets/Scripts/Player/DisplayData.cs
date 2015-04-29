using UnityEngine;
using System.Collections;

public class DisplayData : MonoBehaviour
{
	public Texture2D[] signalIcons;
	
	private int indexSignalIcons = 1;
	
    TGCConnectionController controller;

    public static int poorSignal1;
    public static int attention1;
    public static int meditation1;

	// Testing brain wave indicator bar
	public float barDisplayFoc; //current progress for focus
	public float barDisplayMed; //current progress for meditation
	public Vector2 posFoc = new Vector2(20,40);
	public Vector2 sizeFoc = new Vector2(80,20);
	public Vector2 posMed = new Vector2(20,60);
	public Vector2 sizeMed = new Vector2(80,20);
	public Texture2D focusTex;
	public Texture2D meditationTex;
	public Texture2D backgroundTex;

    void Start()
    {
		CardboardGUI.onGUICallback += this.OnGUI;
		controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;		
    }
	
	void OnUpdatePoorSignal(int value){
		poorSignal1 = value;
		if(value < 25){
      		indexSignalIcons = 0;
		}else if(value >= 25 && value < 51){
      		indexSignalIcons = 4;
		}else if(value >= 51 && value < 78){
      		indexSignalIcons = 3;
		}else if(value >= 78 && value < 107){
      		indexSignalIcons = 2;
		}else if(value >= 107){
      		indexSignalIcons = 1;
		}
	}
	void OnUpdateAttention(int value){
		attention1 = value;
	}
	void OnUpdateMeditation(int value){
		meditation1 = value;
	}


    void OnGUI()
	{
		// ************ THIS SEEMS TO BE A PROBlEM?
		//if (!CardboardGUI.OKToDraw (this))
		//	return;

		// debug information, not relevant to Cardboard implementation
		GUILayout.BeginHorizontal();

        if (GUILayout.Button("Connect"))
        {
            controller.Connect();
        }
        if (GUILayout.Button("Disconnect"))
        {
            controller.Disconnect();
			indexSignalIcons = 1;
        }
		
		GUILayout.Space(Screen.width-250);
		GUILayout.Label(signalIcons[indexSignalIcons]);
		
		GUILayout.EndHorizontal();

		// Testing brain wave indicator bar 
		//FOCUS BAR: draw the background:
		GUI.BeginGroup(new Rect(posFoc.x, posFoc.y, sizeFoc.x, sizeFoc.y));
		GUI.Box(new Rect(0,0, sizeFoc.x, sizeFoc.y), backgroundTex);
		//draw the filled-in part
		GUI.BeginGroup(new Rect(0,0, sizeFoc.x * barDisplayFoc, sizeFoc.y));
		GUI.Box(new Rect(0,0, sizeFoc.x, sizeFoc.y), focusTex);
		GUI.EndGroup();
		GUI.EndGroup();

		//MEDITATION BAR: draw the background:
		GUI.BeginGroup(new Rect(posMed.x, posMed.y, sizeMed.x, sizeMed.y));
		GUI.Box(new Rect(0,0, sizeMed.x, sizeMed.y), backgroundTex);
		//draw the filled-in part
		GUI.BeginGroup(new Rect(0,0, sizeMed.x * barDisplayMed, sizeMed.y));
		GUI.Box(new Rect(0,0, sizeFoc.x, sizeFoc.y), meditationTex);
		GUI.EndGroup();
		GUI.EndGroup();
    }

	// testing brain wave indicator bar

	void Update() {
		//tested with time to see if it worked
		//barDisplayFoc = Time.time*0.05f;
		//barDisplayMed = Time.time*0.05f;
		barDisplayFoc = attention1*0.01f;
		barDisplayMed = meditation1*0.01f;
	}
}
