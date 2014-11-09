using UnityEngine;
using System.Collections;

public class Dialogs : MonoBehaviour {

	private string[] Armoire = {
		 						"Angelia!!", "Ah..... Damn it", "WTF am I?"

	};

	private string[] Bedroom = {" ", " "


	};

	private string[] LivingRoom = {" ", " "

	};

	public string getDialogs(int storyline, int level){
		if (level == 1 && storyline < Armoire.Length){
			return Armoire[storyline];
		}else{
			return "END";
		}
	}
}
