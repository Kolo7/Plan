using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject[] enemyPre;
	// Use this for initialization
	void Start () {
		float s = 3f;
		InvokeRepeating("CreateEnemy",0, s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateEnemy()
	{
		int index = Random.Range (0,10);
		if (index < 7) {
			index = 0;
		} else {
			index = 1;
		}
		Instantiate(enemyPre[index],
			transform.position,
			Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
