using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryExplosion : MonoBehaviour {
	public float time = 2f;
	// Use this for initialization
	void Start () {
		
		Destroy (gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
