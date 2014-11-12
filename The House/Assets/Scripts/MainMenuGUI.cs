using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Texture of logo
	public Texture logo;
	// Texture of start pic
	public Texture start;
	// Texture of team pic
	public Texture team;
	// Create own GUI style
	public GUIStyle myStyle;

	// Function that creates GUI for Main Menu
	void OnGUI(){
		// Define the area of own GUI Style
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height), myStyle);
		// Create logo of game
		GUI.DrawTexture(new Rect(0,0,Screen.width/2,Screen.height/2), logo, ScaleMode.ScaleToFit, true, 10.0f);
		// Create button that could start game
		if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.6f, Screen.width * 0.2f, Screen.height * 0.2f), start, myStyle)){
			Application.LoadLevel("Armoire");
		}
		// Create button that could turn to team scene
		if (GUI.Button(new Rect(Screen.width * 0.72f, Screen.height * 0.7f, Screen.width * 0.15f, Screen.height * 0.2f), team, myStyle)){
			Application.LoadLevel("Team");
		}
		/*if (GUI.Button(new Rect(Screen.width * 0.72f, Screen.height * 0.8f, Screen.width * 0.15f, Screen.height * 0.2f), team, myStyle)){
			Application.Quit();
		}*/
		// Define the area of own GUI Style
		GUILayout.EndArea ();
	}

}
