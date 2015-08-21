#pragma strict

var soundToPlay:AudioClip;

function OnTriggerEnter2D () {
	GetComponent.<AudioSource>().PlayOneShot(soundToPlay);
}