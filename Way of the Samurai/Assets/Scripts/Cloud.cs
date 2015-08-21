using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	
	float StartingPos;
	float endPos;
	
	public int unitsToMove = 5; //Start n end position
	public int moveSpeed = 2; // speed
	bool moveRight = true; //enemy move right or left

	
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
		}
		if (!moveRight) {
			GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (GetComponent<Rigidbody>().position.x <= StartingPos) {
			moveRight = true;
		}
	}
}