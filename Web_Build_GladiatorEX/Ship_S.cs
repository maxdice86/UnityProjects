using UnityEngine;
using System.Collections;

public class Ship_S : MonoBehaviour {


	float left_right;
	float up_down;
	Rigidbody shipbody;
	public float shipspeed;

	public AudioClip hit;

	private AudioSource Source;

	public GameObject explosion;

	void Start(){
	
		shipbody = GetComponent<Rigidbody> ();
		Source = GetComponent<AudioSource>();
	}

	void Update(){

		left_right  =	Input.GetAxis ("Horizontal");
		up_down  = Input.GetAxis ("Vertical");
		MovementX (left_right);
		MovementY (up_down);
		ShipOffScreen();

	
	}

	void MovementX( float left_right ){
	

		shipbody.velocity =  new Vector2 (left_right*shipspeed,shipbody.velocity.y);

		}

	void MovementY ( float up_down ){


		shipbody.velocity =  new Vector2 (shipbody.velocity.x,up_down*shipspeed);

	}

	void OnCollisionEnter( Collision rocks){

		float lowVol = 0.8F;
		float hiVol = 1F;
		float lowPit = 0.55F;
		float hiPit = 0.75F;

		float vol = Random.Range (lowVol, hiVol);
		float pit = Random.Range (lowPit, hiPit);

		Source.pitch = pit;
		Source.PlayOneShot (hit, vol);


		Destroy (rocks.gameObject);

		Instantiate (explosion, rocks.transform.position, Quaternion.identity);
	}



	void ShipOffScreen(){



	       if (transform.localPosition.x > 6.5f) {

				Debug.Log("ship limit right");

			shipbody.AddForce (Vector2.left*1000f);
			}

			if (transform.localPosition.x < -6.5f){
			
				Debug.Log("ship limit left");

			shipbody.AddForce (Vector2.right*1000f);
			}

			if (transform.localPosition.y > 3.5f){

				Debug.Log(" ship limit down");

			shipbody.AddForce (Vector2.down*1000f);

			}

			if (transform.localPosition.y < -3.5f){

				Debug.Log("ship limit up");

			shipbody.AddForce (Vector2.up*1000f);

			}
			
		}


}