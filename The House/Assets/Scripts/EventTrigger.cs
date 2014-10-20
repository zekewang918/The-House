using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {

	public float rayLength;
	public GameObject player;


	void Start(){
	}

	void TouchEvent(){
		// Create a ray named eventToucher from its position and aim forward
		Ray eventToucher = new Ray (player.transform.position, Vector3.forward);
		// Create a raycast called hit
		RaycastHit hit;
		Debug.DrawRay (player.transform.position, Vector3.forward);
		// If the Raycast hit a collider that tag is event
		if (Physics.Raycast(eventToucher, out hit, 0.3f)){
			// Check if the collider that hits is Enemy
			
			if(hit.collider.tag == "Event"){
				// Destroy game object

			}
		
		}
	}
}
