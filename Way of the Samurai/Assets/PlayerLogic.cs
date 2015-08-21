using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {
	public bool interact = false;
	public Transform LineStart, LineEnd;

	RaycastHit2D whatIHit;
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
	
	}
	void Raycasting()
	{
		Debug.DrawLine(LineStart.position, LineEnd.position, Color.green);

		if(Physics2D.Linecast(LineStart.position, LineEnd.position, 1<<LayerMask.NameToLayer("Enemy")))
		{
			whatIHit = Physics2D.Linecast(LineStart.position, LineEnd.position, 1<<LayerMask.NameToLayer("Enemy"));//store in Hit variable when hit an enemy
			interact = true;
		}
		else
		{
			interact = false;
		}
		if(Input.GetButtonDown("f")&&interact == true)
		{
			Destroy (whatIHit.collider.gameObject);
		}
		if (Input.GetButtonDown ("Fire2")&& interact == true) {
			Destroy (whatIHit.collider.gameObject);
		}
		Physics2D.IgnoreLayerCollision (8,9);
	}
}
