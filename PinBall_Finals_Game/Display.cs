using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {

	Text score;
	Text num_ball;
	Text game_status;


	// Use this for initialization
	void Start () {
	
		score = GameObject.Find("Score").GetComponent<Text>();
		num_ball = GameObject.Find("N_balls").GetComponent<Text>();
		game_status = GameObject.Find("Ready").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

		// below puts text on screen, such as the score and credits, 
	
		score.text = "Score: " + GameObject.Find("Ball").GetComponent<Ball_Script>().score.ToString ("0");

		num_ball.text = "Credit: " + GameObject.Find("Ball").GetComponent<Ball_Script>().balls.ToString ("0");

		if (GameObject.Find ("Ball").GetComponent<Ball_Script> ().ready == true) {
		
			game_status.text = "READY";
		
		} else game_status.text = "";

		if (GameObject.Find ("Ball").GetComponent<Ball_Script> ().gameover == true)

			game_status.text = "GAME OVER";
	}
}
