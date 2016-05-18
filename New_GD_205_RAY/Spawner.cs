using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Spawner : MonoBehaviour {

	public Rigidbody enemy;
	public GameObject en;
	public Transform spawnlocation;
	public Vector3 playerlocal;
	public Transform player;
	public float timer;
	public int score;

	Text screen;
	Text healthbar;
	Text gameover; 

	float x;
	float y;
	Vector3 ranSpawn;
	float enSpeed;
	public int health;
	public bool lose;
	public bool alive;


	void Start () {
	
		screen = gameObject.GetComponent<Text>();

		healthbar= GameObject.Find("Healthbar").GetComponent<Text>();

		gameover = GameObject.Find("GameOver").GetComponent<Text>();

		score = 0;
		timer = 20f;
		health = 100;
		lose = false;
		alive = true;
	}
	
	// Update is called once per frame

	void Update () {
	
		screen.text = score.ToString ("0");  // ADDS SCORE TO SCREEN

		healthbar.text = health.ToString ("0"); //ADDS HEALTH TO SCREEN

		if (health <= 0) {  // CHECKS IF HEALTH IS 0 IF SO END GAME

			lose = true;

			alive = false;

			gameover.text = " GAME OVER";  

		}

		if (alive) {  // CHECK IF PLAYER ALIVE IF SO SET TIMER, AND SPAWN VARIABLES
			
			Attack ();

			timer -= Time.deltaTime;

			playerlocal = player.position;

			x = Random.Range (-10f, 10f);
			y = Random.Range (-10f, 10f);


			ranSpawn = new Vector3 (x, y, 20);
			enSpeed = Random.Range (300f, 600f);

			if (timer <= 0) {
		
				timer = 20f;
			}
		}

	}

	void Attack(){
	
		// CHECK TIMER AND CREATES ENEMIES WITH DIRECTION EVERY 10 SECONDS

			if (timer > 10) {
	
				Vector3 direction = Vector3.Normalize (playerlocal - spawnlocation.position);

				Rigidbody moveEnemy;

				moveEnemy = Instantiate (enemy, spawnlocation.position + ranSpawn, spawnlocation.rotation) as Rigidbody;

				moveEnemy.transform.parent = GameObject.Find ("EnemySpawner").transform;

				moveEnemy.AddForce (direction * enSpeed);

				//Debug.Log(direction);

			}


	}
}
