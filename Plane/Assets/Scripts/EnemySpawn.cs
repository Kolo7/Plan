using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject[] enemyPre;
	public GameObject[] bossPre;
	// Use this for initialization
	void Start () {
		float enemyTime = 4f;
		float bossTime = 30f;
		InvokeRepeating("CreateEnemy",0, enemyTime);
		InvokeRepeating("CreateBoss",0, bossTime);
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

	void CreateBoss(){
		Instantiate(bossPre[0],
			transform.position,
			Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
