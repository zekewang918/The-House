using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	private string[] Armoire = {
		 						"Angelia!!", "Ah..... Damn it", "WTF am I?"

	};
	void Start(){

	}
	public string getStoryLines(int storyline, int level){
		if (level == 1){
			return Armoire[storyline];
		}
		return "END";
	}
}
