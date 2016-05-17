using UnityEngine;
using System.Collections;


public class Ball_Script : MonoBehaviour {


	public Transform ball_launch;
	public float balls,score,timer,power,powerlimit;
	private Rigidbody ballbody;
	public bool ready,gameover;
	public GameObject hitvfx;

	private AudioSource m_source;
	public AudioClip m_yhit;
	public AudioClip m_ghit;
	public AudioClip m_bhit;
	public AudioClip m_flip;
	public AudioClip m_out;
	public AudioClip m_launch;
	public AudioClip m_lose;
	public AudioClip m_wall;
	public AudioSource m_off;


	// Use this for initialization
	void Start () {
	
		m_source = GetComponent<AudioSource> ();
		ballbody= GetComponent<Rigidbody>();

		transform.position = ball_launch.position;

		ready = true;
		gameover = false;

		balls = 3;
		score = 0;
		timer = 0;
		power = 0f;
		powerlimit = 20f;


	}
	
	// Update is called once per frame
	void Update () {

		Ray ballray = new Ray (transform.position, Vector3.back);  //make ray for ball

		Debug.DrawRay (ballray.origin, ballray.direction * 1f, Color.green);

		RaycastHit home;

		if (Physics.Raycast (ballray, out home, 0.5f)) {  // check if ball hit launch pad to rest its position

			if (home.collider.tag == "launch") {
			
				transform.position = ball_launch.position;

				ready = true;
			
			}

		}
			

		if (balls <= 0) {   // check game over status 
			
			gameover = true;

			transform.position = ball_launch.position;

			GameObject.Find ("Main Camera").GetComponent<AudioSource>().mute=true;

			//m_off.Mute;

			m_source.PlayOneShot (m_lose, 0.2f);

		}

		if (!gameover) {

			if (balls > 0 & ready) {    // hold space to add power to the ball
			
				if (Input.GetKey (KeyCode.Space)) {

					power += 0.5f;
					if (power >= powerlimit) {
			
						power = powerlimit;
					}

				}

				if (Input.GetKeyUp (KeyCode.Space)) {  // release space to fire ball

					Debug.Log (power);

					ballbody.velocity = Vector3.forward * power;

					m_source.PlayOneShot (m_launch, 0.5f);

					ready = false;
				}
			}
		}	
	}

	void OnCollisionEnter (Collision other) {

		// belowe checks collisions with game objects

		if (other.gameObject.tag == "y_hit") {
		
			m_source.PlayOneShot (m_yhit, 0.5f);
			score += 300;
		
		}

		if (other.gameObject.tag == "g_hit") {
		
			m_source.PlayOneShot (m_ghit, 0.5f);
			score += 100;
		
		}

		if (other.gameObject.tag == "b_hit") {
		
			m_source.PlayOneShot (m_bhit, 0.5f);
			score += 200;
		}

		if (other.gameObject.tag == "flip") {

			m_source.PlayOneShot (m_flip, 0.5f);

		}

		if (other.gameObject.tag == "wall") {

			m_source.PlayOneShot (m_wall, 0.5f);

		}

		if (other.gameObject.tag == "outofplay") {
		
			m_source.PlayOneShot (m_out, 1f);

			balls -= 1;

			transform.position = ball_launch.position;

			if (balls > 0) { ready = true;}
					
		}

	}

}