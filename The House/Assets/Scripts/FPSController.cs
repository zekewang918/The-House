using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Require a GAME GUI to be attachd to the same game object
[RequireComponent(typeof(GameGUI))]
// Require a Event Trigger to be attached to the same game object
[RequireComponent(typeof(EventTrigger))]
// Require a Collect Item to be attached to the same game object
[RequireComponent(typeof(CollectItem))]
public class FPSController : MonoBehaviour
{
	public float speed = 1.0f;

	// Create a CharacterMotor called motor
	//private CharacterMotor motor;
	// Create a EventTrigger called et
	private EventTrigger et;
	// Create a CollectItem called ct
	private CollectItem ct;

	private GameGUI gameGUI; 

	private LightControl lc;

	//private CharacterItem ci;

	private bool isStand = false;

	private string item = "Hand";

	// Use this for initialization
	void Start()
	{
		et = GetComponent<EventTrigger> ();
		//motor = GetComponent<CharacterMotor>();
		ct = GetComponent<CollectItem> ();
		gameGUI = GetComponent<GameGUI> ();
		lc = GetComponent<LightControl> ();
		//ci = GetComponent<CharacterItem>();

	}
	
	// Update is called once per frame
	void Update()
	{

		if(CheckIfControl ()){
			// Do move and jump 

			Move ();
			// Inspect Events
			EventInspector ();
			// Change item if user press 1-6
			ChangeItem ();
			// Collect item if user click collectable item
			CollectItem ();

			TrigItem ();
		}

	}
	void Move(){
		// Get the input vector from kayboard or analog stick
		/*Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		if (directionVector != Vector3.zero)
		{
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			float directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1.0f, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}
		
		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = transform.rotation * directionVector;
		motor.inputJump = Input.GetButton("Jump");*/

		//this.GetComponent<Animation>().Play("Stand");
		if (Input.GetKey(KeyCode.W)){
			this.transform.Translate(0, 0, Time.deltaTime * speed, Space.Self);
			this.GetComponent<Animation>().Play("Walk");
		}
		/*if (Input.GetKey(KeyCode.A)){
			this.transform.Translate(-Time.deltaTime * speed/2, 0, 0, Space.Self);
			this.GetComponent<Animation>().Play("Walk");
		}
		if (Input.GetKey(KeyCode.D)){
			this.transform.Translate(Time.deltaTime * speed/2, 0, 0, Space.Self);
			this.GetComponent<Animation>().Play("Walk");
		}*/
		if (Input.GetKey(KeyCode.S)){
			this.transform.Translate(0, 0, -Time.deltaTime * speed/2, Space.Self);
			this.GetComponent<Animation>().Play("Walk");
		}
	}
	// Function that collects items
	void CollectItem(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			GameObject target = hit.collider.gameObject;
			if(Input.GetMouseButton(0))
			{
				if (target.tag == "Item"){
					if (ct.CheckIfCollectable(target.name)){
						Destroy(target);
						gameGUI.haveItems[ct.markHasItem(target.name)] = true;
					}
				}
			}
		}
	}
	void TrigItem(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			GameObject target = hit.collider.gameObject;
			if(Input.GetMouseButton(0))
			{
				if (target.tag == "Switch"){
					//print ("OYO");
					lc.controlLight();
				}
			}
		}
		if (Physics.Raycast (ray, out hit, 100)) {
			GameObject target = hit.collider.gameObject;
			if(Input.GetMouseButton(0) && item == "Knife")
			{
				if (target.tag == "Rope"){
					Destroy(target);
					gameGUI.storyline++;
				}
			}
		}


	}
	// Function that changes items
	void ChangeItem(){
		if (Input.GetKey(KeyCode.Alpha1) && gameGUI.haveItems[0] == true){
			item = "Hand";
			print(item);
		}
		if (Input.GetKey(KeyCode.Alpha2) && gameGUI.haveItems[1] == true){
			item = "Knife";
			print(item);
		}
		if (Input.GetKey(KeyCode.Alpha3) && gameGUI.haveItems[2] == true){
			item = "FlashLight";
			print(item);
		}
		if (Input.GetKey(KeyCode.Alpha3) && gameGUI.haveItems[3] == true){
			item = "";
			print(item);
		}
		if (Input.GetKey(KeyCode.Alpha3) && gameGUI.haveItems[4] == true){
			item = "";
			print(item);
		}
		if (Input.GetKey(KeyCode.Alpha3) && gameGUI.haveItems[5] == true){
			item = "";
			print(item);
		}

	}
	// Function that triggers the event
	void EventInspector(){
		// If user press the F then event triger check if event can be triggered
		if (Input.GetKey(KeyCode.F)){
			// Check if there is event can be triggered
			et.TouchEvent ();
		}
	}
	bool CheckIfControl(){
		if (gameGUI.level == 1){
			if (gameGUI.storyline <= 2){
				return false;
			}else if (gameGUI.storyline == 4){
				//if(!isStand){
					this.GetComponent<BoxCollider>().enabled = true;
					this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
					this.GetComponent<Animation>().Play("SitToStand");
					gameGUI.cs.player.cullingMask = -257;
					isStand = true;
					gameGUI.storyline++;
				//} 
				return true;
			}else{
				return true;
			}
		}
		return false;
	}

}