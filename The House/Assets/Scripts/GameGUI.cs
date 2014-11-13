using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent(typeof(Dialogs))]
public class GameGUI : MonoBehaviour {

	public Texture[] itemsBG = new Texture[6];

	public Texture[] items = new Texture[6];

	public bool[] haveItems = new bool[6];

	public Texture[] lockPassword = new Texture[4];

	private int[] lockNumber = {0, 0, 0, 0};

	public Texture[] numbers = new Texture[10];

	public Texture dialogBG;
	
	private string message = "";

	private int index = 0;

	public int storyline = 0;

	public int level;

	//private bool storyBegins = true;

	private Dialogs dialog;

	private EventTrigger et;

	public CameraSwitch cs;

	void Start(){
		cs = GetComponent<CameraSwitch> ();
		dialog = GetComponent<Dialogs> ();
		haveItems [0] = true;
		et = GetComponent<EventTrigger> ();
		for (int i = 1; i < haveItems.Length;i++){
			haveItems[i] = false;
		}
		if (EditorApplication.currentScene == "Assets/Scenes/Armoire.unity"){
			level = 1;
		}else if (EditorApplication.currentScene == "Assets/Scenes/Bedroom.unity"){
			level = 2;
		}else if (EditorApplication.currentScene == "Assets/Scenes/Livingroom.unity"){
			level = 3;
		}

		print (EditorApplication.currentScene);

	}

	void Update(){

	}

	void OnGUI(){
		//print(cs.player.cullingMask);
		print (level);
		if(level == 1){
			if (storyline <= 2){
				if (dialogNotEnd()){
					Rect drect = new Rect (Screen.width * 0.15f, Screen.height*0.7f, Screen.width*0.85f, Screen.height*0.3f);
					GUI.DrawTexture (drect, dialogBG);
					GUI.Label (new Rect (Screen.width * 0.20f, Screen.height*0.75f, Screen.width*0.78f, Screen.height*0.23f), message);
				}
				cs.talking2 ();
			}else if (storyline == 6){
				for (int i = 0; i < lockPassword.Length;i++){
					GUI.DrawTexture(new Rect(Screen.width * 0.3f + i * Screen.width * 0.125f,Screen.height * 0.5f,Screen.width* 0.1f,Screen.height* 0.1f), lockPassword[i]);
					if (GUI.Button(new Rect(Screen.width*0.3f+i*Screen.width*0.125f, Screen.height*0.4f, Screen.width*0.1f, Screen.height* 0.1f), "+")){
						if (lockNumber[i] < 9){
							lockPassword[i] = numbers[lockNumber[i]+1];
							lockNumber[i]++;
						}else{
							lockPassword[i] = numbers[0];
							lockNumber[i] = 0;
						}
					}
					if(et.checkPassword(lockNumber)){
						storyline = 7;
						GameObject.FindWithTag("Armoire-Door").GetComponent<Animator>().Play("OpenDoor");
					}
				}
			}else{
				cs.stopTalking2();
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
