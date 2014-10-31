using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public Camera player;
	public Camera armoire_locker;
	public Camera CharacterFace;

	public void cameraSwitch(int n){
		if (n == 0){
			player.enabled = true;
			armoire_locker.enabled = false;
		}else if (n == 1){
			player.enabled = false;
			armoire_locker.enabled = true;
		}
	}
	public void talking(){
		CharacterFace.enabled = true;
	}
}
