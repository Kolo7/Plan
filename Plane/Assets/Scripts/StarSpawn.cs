using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour {
	public GameObject[] enemyPre;
	// Use this for initialization
	void Start () {
		float s = 5f;
		InvokeRepeating("CreateStar",0, s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateStar()
	{
		int index = Random.Range (0,10);
		if (index < 5) {
			index = 0;
		} else if (index < 7) {
			index = 1;
		} else {
			index = 2;
		}
		Instantiate(enemyPre[index],
			transform.position,
			Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
