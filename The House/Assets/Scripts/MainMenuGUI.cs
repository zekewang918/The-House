using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	public Texture logo;
	public Texture start;
	public Texture team;
	public GUIStyle myStyle;

	void OnGUI(){
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height), myStyle);
		GUI.DrawTexture(new Rect(0,0,Screen.width/2,Screen.height/2), logo, ScaleMode.ScaleToFit, true, 10.0f);
		//if (GUI.DrawTexture (new Rect (Screen.width * 0.7f, Screen.height * 0.6f, Screen.width * 0.2f, Screen.height * 0.2f), start, ScaleMode.ScaleToFit, true, 10.0f)) {
		//	Application.LoadLevel("Armoire");
		//}
		//GUI.DrawTexture(new Rect(Screen.width * 0.7f, Screen.height * 0.7f, Screen.width * 0.15f, Screen.height * 0.2f), team, ScaleMode.ScaleToFit, true, 10.0f);

		if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.6f, Screen.width * 0.2f, Screen.height * 0.2f), start, myStyle)){
			Application.LoadLevel("Armoire");
		}
		if (GUI.Button(new Rect(Screen.width * 0.72f, Screen.height * 0.7f, Screen.width * 0.15f, Screen.height * 0.2f), team, myStyle)){
			Application.LoadLevel("Team");
		}
		GUILayout.EndArea ();
	}

}
