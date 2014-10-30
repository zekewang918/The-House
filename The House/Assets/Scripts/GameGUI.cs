using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Texture[] items = new Texture[6];

	public string speech = "Ahhhh..... TEST TEST!";

	public Texture dialogBG;

	public GUIText mtext;

	private string temp = "";

	private int index = 0;

	void OnGUI(){
		for (int i = 0; i < 6; i++){
			GUI.DrawTexture(new Rect(Screen.width * 0.2f + i * Screen.width * 0.1f,Screen.height * 0.9f,50.0f,50.0f), items[i]);
		}

		Rect drect = new Rect (Screen.width * 0.15f, Screen.height*0.7f, Screen.width*0.85f, Screen.height*0.3f);
		GUI.DrawTexture (drect, dialogBG);
		if (notEnd()){
			GUI.Label (new Rect (0, 0, 100, 100), temp);
		}
	}
	bool notEnd(){
		if (index < speech.Length){
			temp += speech[index];
			index++;
		}
		return true;
	}

}
