using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour {
	
	//private Hashtable items;
	private string items;
	
	void Start(){
		//items = new Hashtable ();
		//items.Add ("Knife", 1);
		items = "Knife";
	}
	
	public bool CheckIfCollectable(string item){
		/*if(items.ContainsKey(item)){
			return true;
		}
		return false;*/
		if (items == item)
			return true;
		else
			return false;
	}
	public void FUCK(){
		print ("FUCK");
	}
}
