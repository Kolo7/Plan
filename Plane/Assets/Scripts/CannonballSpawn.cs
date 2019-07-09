using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawn : MonoBehaviour {
	public GameObject CannonballPre;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating("CreateCanonball",0,3f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
		
	void CreateCanonball()
	{
		int num = 3;
		int angle = 60;
		for (int i = 1; i <= num; i++) {
			Instantiate(CannonballPre,
				transform.position,
				Quaternion.Euler(new Vector3(0, i*angle/num-40, 0)));
		}
		//GameObject bullet =  Instantiate(CannonballPre,	
		//	transform.position,
		//	Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
