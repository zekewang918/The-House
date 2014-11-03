using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

	public Light Armoire_Light;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void controlLight(){
		Armoire_Light.GetComponent<Light>().enabled = !Armoire_Light.GetComponent<Light>().enabled;
	}
}
