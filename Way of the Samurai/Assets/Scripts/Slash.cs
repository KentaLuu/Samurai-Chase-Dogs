using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	public bool animation_bool;
	// Update is called once per frame
	void Update()
	{
		
		if(animation_bool == true)
		{
			GetComponent<Animator>().Play("Combat");
			
		}
		
		
		if (Input.GetButtonDown ("f")) {
			animation_bool = true; 
		} 
		else if (Input.GetButtonUp ("f")) {
			animation_bool = false;
		}
	}
}