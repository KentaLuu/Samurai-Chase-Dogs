using UnityEngine;
using System.Collections;

public class Stab : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	public bool animation_bool;
	// Update is called once per frame
	void Update () 

		{
		if (animation_bool == true) {
			GetComponent<Animator> ().Play ("Combat1");
		}
		if (Input.GetButtonDown ("Fire2")) {
			animation_bool = true;
		} else if (Input.GetButtonUp ("Fire2")) {
			animation_bool = false;
		}
	
	}
}
