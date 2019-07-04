using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//向前移动
//当超出屏幕的时候销毁子弹
public class Bullet : MonoBehaviour {
    public float speed = 2.0f;
	public int atk = 27;
	public int dir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dir == 0) {
			transform.Translate (Vector3.forward * Time.deltaTime * speed);

			if (transform.position.z >= 10f) {
				Destroy (gameObject);
			}
		} else {
			transform.Translate (Vector3.back * Time.deltaTime * speed);
			if (transform.position.z <= -20f) {
				Destroy (gameObject);
			}
		}
	}

	public void setProperty(int isPlayer){
		if (isPlayer == 1 ) {
			speed = 9.0f;
			atk = 10;
			dir = 1;
		}
	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Plane" && dir == 1) {
			Destroy (gameObject);
			other.GetComponent<Player> ().Hurt (atk);
		}
	}
}
