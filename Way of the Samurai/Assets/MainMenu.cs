using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI(){

		if (GUI.Button(new Rect(Screen.width*.25f,Screen.height*.5f,Screen.width*.5f,Screen.height*.1f),"Play Game"))
		{
			print ("Click Play Game");
			Application.LoadLevel("Samurai");
		}
	}
}