using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public Camera player;
	public Camera armoire_locker;
	public Camera CharacterFace1;
	public Camera CharacterFace2;

	public void cameraSwitch(int n){
		if (n == 0){
			player.enabled = true;
			armoire_locker.enabled = false;
		}else if (n == 1){
			player.enabled = false;
			armoire_locker.enabled = true;
		}
	}
	public void talking2(){
		CharacterFace2.enabled = true;
	}
	public void stopTalking2(){
		CharacterFace2.enabled = false;
	}
	public void talking1(){
		CharacterFace1.enabled = true;
	}
	public void stopTalking1(){
		CharacterFace1.enabled = false;
	}
}
