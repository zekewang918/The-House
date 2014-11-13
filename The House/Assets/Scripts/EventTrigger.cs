using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CameraSwitch))]
public class EventTrigger : MonoBehaviour {

	public float rayLength = 100f;

	private CameraSwitch cs;

	void Start(){
		cs = GetComponent<CameraSwitch> ();
	}

	public void TouchEvent(){
		// Create a ray named eventToucher from its position and aim forward
		Ray eventToucher = new Ray (this.transform.position, Vector3.forward);
		// Create a raycast called hit
		RaycastHit hit;
		Debug.DrawRay (this.transform.position, Vector3.forward, Color.green);
		// If the Raycast hit a collider that tag is event
		if (Physics.Raycast(eventToucher, out hit, rayLength)){
			// Check if the collider that hits is Enemy
			
			if(hit.collider.tag == "Armoire-Door"){
			
			}
		
		}
	}
	public bool checkPassword(int[] password){
		if (password[0] == 6 && password[1] == 9 && password[2] == 0 && password[3] == 3){
			return true;
		}else{
			return false;
		}
	}
}
