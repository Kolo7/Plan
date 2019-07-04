using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpwan : MonoBehaviour {
	public GameObject[] asstoridPre;
	// Use this for initialization

	void Start () {
		float s = 0.6f;
		InvokeRepeating("CreateAsteriod",0, s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateAsteriod()
	{
		int index = Random.Range (0,asstoridPre.Length);
		Instantiate(asstoridPre[index],
			transform.position,
			Quaternion.Euler(new Vector3(0, 0, 0)));
	}
}
