using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelManager : MonoBehaviour {

	public GameObject[] playerModel;
	public static int modelIndex=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameStart(){
		SceneManager.LoadScene("plane");
	}

	public void Next(){
		Debug.Log (modelIndex);
		playerModel [modelIndex].gameObject.SetActive (false);
		modelIndex = (modelIndex + 1) % 2;
		playerModel [modelIndex].gameObject.SetActive (true);
	}

}
