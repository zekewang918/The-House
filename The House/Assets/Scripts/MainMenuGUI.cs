using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	
	private float newW;
	private float newH;

	public Texture logo;

	void OnGUI(){
		GUI.DrawTexture(new Rect(0,0,newW,newH), logo, ScaleMode.ScaleToFit, true, 10.0f);
		
	}
	void Awake(){
		newW = Screen.width / 2;
		newH = Screen.height / 2;

	}
}
