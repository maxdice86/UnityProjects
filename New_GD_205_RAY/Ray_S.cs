using UnityEngine;
using System.Collections;

public class Ray_S : MonoBehaviour {

	public Transform obj;
	public Transform nozzle;
	public Rigidbody bullet;
	private AudioSource m_source;
	public AudioClip m_shot;
	public AudioClip m_hitfx;
	public AudioClip m_destroyfx;
	public Texture2D cross;
	public bool Alive;



	// Use this for initialization
	void Start () {
		
		Cursor.visible = true;

		m_source = GetComponent<AudioSource> ();

		Alive = true;
	}
	
	// Update is called once per frame

	void Update () {
	
		if (GameObject.Find("Canvas").GetComponentInChildren<Spawner> ().alive == false) {
		
			Alive = false;
		
		}

		if (Alive) {
			
			Cursor.SetCursor (cross, Vector2.zero, CursorMode.Auto);

			Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition); // creates ray

			Camera.main.transform.LookAt (myRay.direction * 2.5f); // set camera to look at ray direction

			Debug.DrawRay (myRay.origin, myRay.direction * 1000, Color.red); // draws ray for debug use

			RaycastHit rayhit = new RaycastHit ();


			if (Physics.Raycast (myRay, out rayhit, 1000f) && Input.GetMouseButtonDown (0)) {
		
				//Debug.Log (rayhit.transform);

			}

			if (Input.GetMouseButtonDown (0)) {

				Rigidbody Firing;

				Ray myRay2 = Camera.main.ScreenPointToRay (Input.mousePosition);

				m_source.PlayOneShot (m_shot, 0.15f);

				Firing = Instantiate (bullet, nozzle.position, nozzle.rotation) as Rigidbody;

				Firing.AddForce (myRay2.direction * 1000f);


			}

		}		
	}



}
