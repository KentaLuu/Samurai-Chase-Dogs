using UnityEngine;
using System.Collections;

public class CitizenRun: MonoBehaviour {

	float StartingPos;
		float endPos;

	public int unitsToMove = 5; //Start n end position
	public int moveSpeed = 2; // speed
	bool moveRight = false; //enemy move right or left
	bool facingRight =true; //facing right

	// Use this for initialization
	void Awake () {
		StartingPos = transform.position.x;
		endPos = StartingPos + unitsToMove;
	
	}
	
	// Update is called once per frame
	void Update () {
	if (moveRight) {
			GetComponent<Rigidbody>().position += Vector3.right * moveSpeed * Time.deltaTime;
		}
	if (GetComponent<Rigidbody>().position.x >= endPos) {
			moveRight = false;
			Flip ();
		}
	if (!moveRight) {
			GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;
		}
	if (GetComponent<Rigidbody>().position.x <= StartingPos) {
			moveRight = true;
			Flip ();
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
