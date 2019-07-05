using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
	public float speed = 2.0f;
	public float minX;
	public float maxX;
	public int hp = 10;
	public Vector3 dir = Vector3.left;
	public int type;
	// Use this for initialization
	void Start () {
		float x = Random.Range (minX, maxX);
		transform.position = new Vector3 (x,transform.position.y, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.forward * Time.deltaTime * speed,Space.World);
		transform.Translate (dir * Time.deltaTime * speed);
		if (transform.position.x <= minX ) {
			transform.position = new Vector3 (minX, transform.position.y, transform.position.z);
			dir = Vector3.right;
		}else if(transform.position.x >= maxX){
			transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
			dir = Vector3.left;
		}
		if (transform.position.z <= -17.24f) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter(Collider other){
		if (other.tag == "Plane" ) {
			
			Player play =  other.GetComponent<Player> ();
			if (type == 0)
				play.AddHP (GetHP ());
			else if (type == 1)
				play.Sandan ();
			else if (type == 2)
				play.OpenHudun ();
			Die ();
		}

	}

	public void Die(){
		Destroy (gameObject);
	}

	public int GetHP(){
		return hp;
	}
}
