using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move_S : MonoBehaviour {

	public GameObject[] Roids;
	public Rigidbody[] Rigi;
	public GameObject ship;
	public Vector3 destination;
	public GameObject[] NewRoids;
	public float rockspeed;


	void Start () {

	Roids = GameObject.FindGameObjectsWithTag ("Player");

	}
		
      void Update () {

		Roids = GameObject.FindGameObjectsWithTag ("Player");

		Rigi  = Rigidbody.FindObjectsOfType<Rigidbody>();

		RockUpdate ();
		Control ();
		OffScreen ();

	
	}

	void RockUpdate(){

		destination = ship.transform.position;

		foreach (GameObject force in Roids) {

			Vector3 direction =  Vector3.Normalize (destination - force.transform.position);

			force.GetComponent<Rigidbody> ().AddForce(direction * rockspeed);

		}

	}

	void Control() {
	
		if (Input.GetKeyDown (KeyCode.Space)) {

			foreach (GameObject spawn in NewRoids) {
				
				GameObject	respawn =Instantiate (spawn, transform.position,Quaternion.identity) as GameObject;

				respawn.transform.parent = GameObject.Find ("Controller").transform;

			}
	
		}
	}
		
	void OffScreen(){

		foreach (GameObject force in Roids){

			if (force.transform.localPosition.x > 6.5f){

				Debug.Log("limit right");
			
				force.GetComponent<Rigidbody> ().velocity = Vector3.left;
		
			}

			if (force.transform.localPosition.x < -6.5f){

				Debug.Log("limit left");

				force.GetComponent<Rigidbody> ().velocity = Vector3.right;

			}

			if (force.transform.localPosition.y > 3.5f){

				Debug.Log("limit down");

				force.GetComponent<Rigidbody> ().velocity = Vector3.down;

			}

			if (force.transform.localPosition.y < -3.5f){

				Debug.Log("limit up");

				force.GetComponent<Rigidbody> ().velocity = Vector3.up;

			}

			if (force.transform.localPosition.z < -1.0f ){

				Debug.Log("limit up");

				force.GetComponent<Rigidbody> ().velocity = Vector3.forward;

			}

			if (force.transform.localPosition.z > 1.05f){

				Debug.Log("limit up");

				force.GetComponent<Rigidbody> ().velocity = Vector3.back;

			}

		}

}
		

}