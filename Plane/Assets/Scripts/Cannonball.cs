using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour {
	public float speed = 2.0f;
	public int atk = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.back * Time.deltaTime * speed);
		if (transform.position.z <= -20f) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Plane") {
			Destroy (gameObject);
			other.GetComponent<Player> ().Hurt (atk);
		} else if(other.tag == "Bullet2"){
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
