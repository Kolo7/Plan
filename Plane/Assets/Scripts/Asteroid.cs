using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float speed = 3f;
	public float minX;
	public float maxX;
	public int hp = 50;
	public GameObject asteroidExp;
	public MeshRenderer meshRenderer;
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

		meshRenderer.material.color = Color.Lerp (meshRenderer.material.color, Color.white, Time.deltaTime*2f);
	}

	private void OnTriggerEnter(Collider other){
		
		if (other.tag == "Bullet") {
			if (other.GetComponent<Bullet> ().dir == 0) {
				Destroy (other.gameObject);
				Hurt(other.GetComponent<Bullet> ().atk);
			}

		}else if (other.tag == "Plane") {
			if (other.GetComponent<Player> ().hudunStatus == 0) {
				Die ();
				Player plalyerProperty = other.GetComponent<Player> ();
				plalyerProperty.Hurt (30);
			}

		}
	}

	public void Hurt(int atk){
		if (hp > 0) {
			hp -= atk;
			if (hp <= 0) {
				hp = 0;
				Die ();
			} else {
				Color color;
				color.r = Random.Range (0f,1f);
				color.g = Random.Range (0f,0.2f);
				color.b = Random.Range (0f,0.2f);
				color.a = Random.Range (0f, 1f);
				meshRenderer.material.color = color;
			}
		}
	}
		
	public void Die(){
		Destroy (gameObject);
		GameObject exp = Instantiate (asteroidExp,transform.position ,Quaternion.identity);
		Destroy (exp, 1f);
	}
}

