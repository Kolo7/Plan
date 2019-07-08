using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
	public float speed;
	public float maxX;
	public float minX;
	public float upZ;
	public float downZ;
	public int hp = 50;
	public Vector3 dir = Vector3.left;
	public MeshRenderer meshRenderer;
	public GameObject enemyExp;

	private GameObject socerManager;
	// Use this for initialization
	void Start () {
		socerManager = GameObject.FindGameObjectWithTag ("UIManager");
		float x = Random.Range (minX, maxX);
		transform.position = new Vector3 (x,transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z>=upZ)
			transform.Translate (-Vector3.forward * Time.deltaTime * speed,Space.World);
		if(transform.position.z<=downZ)
			transform.Translate (Vector3.forward * Time.deltaTime * speed,Space.World);
		transform.Translate (dir * Time.deltaTime * speed);
		if (transform.position.x <= minX ) {
			transform.position = new Vector3 (minX, transform.position.y, transform.position.z);
			dir = Vector3.right;
		}else if(transform.position.x >= maxX){
			transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
			dir = Vector3.left;
		}
		meshRenderer.material.color = Color.Lerp (meshRenderer.material.color, Color.white, Time.deltaTime*2f);
	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Bullet2") {

			Destroy (other.gameObject);
			Hurt(other.GetComponent<Bullet> ().atk);
		}else if (other.tag == "Plane") {
			if (other.GetComponent<Player> ().hudunStatus == 0) {
				Hurt (100);
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
		socerManager.GetComponent<UIManager> ().socre += 100;
		Destroy (gameObject);
		GameObject exp = Instantiate (enemyExp,transform.position ,Quaternion.identity);
		Destroy (exp, 1f);

	}
}
