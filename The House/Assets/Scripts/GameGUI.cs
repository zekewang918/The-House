using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Dialogs))]
public class GameGUI : MonoBehaviour {

	public Texture[] itemsBG = new Texture[6];

	public Texture[] items = new Texture[6];

	public bool[] haveItems = new bool[6];

	public Texture[] lockPassword = new Texture[4];

	public Texture dialogBG;
	
	private string message = "";

	private int index = 0;

	public int storyline = 0;

	public int level = 1;

	//private bool storyBegins = true;

	private Dialogs dialog;

	private CameraSwitch cs;

	void Start(){
		cs = GetComponent<CameraSwitch> ();
		dialog = GetComponent<Dialogs> ();
		haveItems [0] = true;
		for (int i = 1; i < haveItems.Length;i++){
			haveItems[i] = false;
		}
	}

	void Update(){

	}

	void OnGUI(){

		if(level == 1){
			if (storyline <= 2){
				if (dialogNotEnd()){
					Rect drect = new Rect (Screen.width * 0.15f, Screen.height*0.7f, Screen.width*0.85f, Screen.height*0.3f);
					GUI.DrawTexture (drect, dialogBG);
					GUI.Label (new Rect (Screen.width * 0.20f, Screen.height*0.75f, Screen.width*0.78f, Screen.height*0.23f), message);
				}
				cs.talking ();
			}else{
				for (int i = 0; i < 6; i++){
					GUI.DrawTexture(new Rect(Screen.width * 0.2f + i * Screen.width * 0.1f,Screen.height * 0.9f,50.0f,50.0f), itemsBG[i]);
				}
				
				for (int i = 0; i < 6; i++){
					if (haveItems[i] == true){
						GUI.DrawTexture(new Rect(Screen.width * 0.2f + i * Screen.width * 0.1f,Screen.height * 0.9f,50.0f,50.0f), items[i]);
					}
				}

			}
		}
	}
	bool dialogNotEnd(){
		if (index < dialog.getDialogs(storyline, level).Length){ 
			string temp = dialog.getDialogs(storyline, level);
			/*if (temp == "END"){
				//storyBegins = false;
				return false;
			}*/
			message += temp[index];
			index++;
			return true;
		}else{
			if(Input.GetMouseButton(0)){
				index = 0;
				message = "";
				storyline++;
			}
			return true;
		}

	}

}
