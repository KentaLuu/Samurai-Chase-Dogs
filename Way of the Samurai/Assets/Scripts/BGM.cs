using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	public bool interact = false;
	public AudioSource _AudioSource1;
	public AudioSource _AudioSource2;
	
	void Start() 
	{
		
		_AudioSource1.Play();
		
	}

	/*void OnCollisionEnter2D(Collider2D other){
		interact = true;
	}*/
	
	
	void Update () 
	{
		
		if (interact == true)
		{
			
			if (_AudioSource1.isPlaying)
			{
				
				_AudioSource1.Stop();
				
				_AudioSource2.Play();
				
			}
			
			else
			{
				
				_AudioSource2.Stop();
				
				_AudioSource1.Play();
				
			}
			
		}
		
	}
}
