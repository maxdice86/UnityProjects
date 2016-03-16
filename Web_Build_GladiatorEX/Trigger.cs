using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public AudioClip hit;

	private AudioSource Source;


	void Start(){
	
		Source = GetComponent<AudioSource>();

	}
		

	void OnCollisionEnter (Collision other)
	{


		Debug.Log ("Got Hit");

	}

}


