using UnityEngine;
using System.Collections;

public class Destroy_Pre : MonoBehaviour {


	private AudioSource hitsource;
	private AudioClip hit;


	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, 1.5f);

		hitsource = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		hit = GameObject.Find ("Main Camera").GetComponent<Ray_S> ().m_hitfx; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision other){

		float lowVol = 0.2F;
		float hiVol = 1F;
		float lowPit = 0.55F;
		float hiPit = 0.75F;

		float vol = Random.Range (lowVol, hiVol);
		float pit = Random.Range (lowPit, hiPit);

		hitsource.pitch = pit;
	
		if (other.gameObject.tag == "Enemy") {
		
			hitsource.PlayOneShot (hit, vol);

			GameObject.Find("Canvas").GetComponentInChildren<Spawner> ().score += 100;

			Destroy (other.gameObject);



		}
	
	}
}
