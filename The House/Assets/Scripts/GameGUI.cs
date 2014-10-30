using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Texture[] items = new Texture[6];

	void OnGUI(){
		for (int i = 0; i < 6; i++){
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + i * Screen.width * 0.1f,Screen.height * 0.9f,50.0f,50.0f), items[i]);
		}
	}
}
