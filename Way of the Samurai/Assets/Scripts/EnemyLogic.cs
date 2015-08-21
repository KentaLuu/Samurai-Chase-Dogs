using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	Animator anim;

	public Transform sightStart, sightEnd;
	public bool spotted = false;
	public bool facingLeft = true;

	void Start()
	{
		anim = GetComponent<Animator>();
		InvokeRepeating ("Patrol", 0f,Random.Range (3f, 5f));
	}
	public bool animation_bool;
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Behaviours ();
		if (animation_bool == true) {
			GetComponent<Animator> ().Play ("Combat");
		}
		if (spotted == true) {
			animation_bool = true;
		} else {
			animation_bool = false;
		}


	}
	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast(sightStart.position,sightEnd.position, 1<<LayerMask.NameToLayer("Player"));
}
	void Behaviours(){
		if (spotted == true) {
			Application.LoadLevel ("Main Menu");
		}
	}

	void Patrol()
	{
		facingLeft = !facingLeft;//true is false, false is true, sooo real :D

		if (facingLeft == true) {
			transform.eulerAngles = new Vector2 (0, 0);
		} 
		else {
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}
}
