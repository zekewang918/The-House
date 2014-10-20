using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TouchEvent ();
	}

	void TouchEvent(){
		// Create a ray named hitEnemy from its position and aim down
		Ray eventToucher = new Ray (this.transform.position, Vector3.forward);
		// Create a raycast called hit
		RaycastHit hit;
		Debug.DrawRay (this.transform.position, Vector3.forward);
		// If the Raycast hit a collider that tag is enyme then destory it.
		if (Physics.Raycast(eventToucher, out hit, 0.3f)){
			// Check if the collider that hits is Enemy
			
			if(hit.collider.tag == "Event"){
				// Destroy game object

			}
		
		}
	}
}
