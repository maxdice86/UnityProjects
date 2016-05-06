using UnityEngine;
using System.Collections;

public class En_Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

		Destroy (gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision player){
	
		if (player.gameObject.tag == "Player") {
		
			GameObject.Find("Canvas").GetComponentInChildren<Spawner> ().health -=20;

			Debug.Log (player);
		}
	
	}
}
