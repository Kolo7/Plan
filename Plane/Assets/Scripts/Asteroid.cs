using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float speed = 3f;
	public float minX;
	public float maxX;
	public GameObject asteroidExp;
	// Use this for initialization
	void Start () {
		float x = Random.Range (minX, maxX);
		transform.position = new Vector3 (x,transform.position.y, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.forward * Time.deltaTime * speed,Space.World);
		if (transform.position.z <= -20.0f) {
			Destroy (gameObject);
		}
		transform.Rotate (Time.deltaTime * 100, 0, Time.deltaTime * 100);
	}

	private void OnTriggerEnter(Collider other){
		
		Destroy (other.gameObject);
		Die ();
	}

	public void Die(){
		Destroy (gameObject);
		Instantiate (asteroidExp,transform.position ,Quaternion.identity);
	}
}

