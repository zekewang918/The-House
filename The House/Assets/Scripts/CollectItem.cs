using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour {
	
	//private Hashtable items;
	private string[] items = {"Hand", "Knife", "FlashLight"};
	
	void Start(){
		//items = new Hashtable ();
		//items.Add ("Knife", 1);
		//items.Add ("FlashLight", 2);
		//items = "Knife";
	}
	
	public bool CheckIfCollectable(string item){
		/*if(items.ContainsKey(item)){
			return true;
		}
		return false;*/
		for (int i = 1; i < items.Length; i++){
			if (items[i] == item)
				return true;
		}
		return false;
	}
	public void FUCK(){
		print ("FUCK");
	}
	public int markHasItem(string item){
		for (int i = 1; i < items.Length; i++){
			if (items[i] == item)
				return i;
		}
		return -1;
	}
}
