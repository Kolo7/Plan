using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Button startButton;
	public Text socerText;
	public int socer;
	public 
	// Use this for initialization
	public void StartGame()
	{
		SceneManager.LoadScene("plane");
	}

	public void Update(){
		if (SceneManager.GetActiveScene ().name == "plane") {
			socerText.text = socer.ToString ();
		}
	}
}
