using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Button startButton;
	public Text socreText;
	public int socre;
	public Button stopButton;
	public GameObject pausePanel;
	private bool pausePanelStatus;
	public Slider voiceSlider;

	public GameObject mainCamera;
	public GameObject bullet;
	public GameObject bullet2;
	public GameObject Explostion_asteroid;
	public GameObject Explostion_player;
	public GameObject Explostion_enemy;
	// Use this for initialization
	void Start(){
		pausePanelStatus = false;
	}
	public void StartGame()
	{
		
		SceneManager.LoadScene("plane");
		ContinueGame ();
	}

	public void Update(){
		
		if (SceneManager.GetActiveScene ().name == "plane") {
			socreText.text = socre.ToString ();
		}
	}

	public void StopGame(){
		Time.timeScale = 0;
		OpenPausePanelActive ();
	}

	public void OverGame(){
		
		SceneManager.LoadScene("StartScene");
	}

	public void ContinueGame(){
		Time.timeScale = 1;
		ClosePausePanelActive ();
	}

	public void ClosePausePanelActive(){
		pausePanel.SetActive (false);
		pausePanelStatus = false;


	}
	public void OpenPausePanelActive(){
		pausePanel.SetActive (true);
		pausePanelStatus = true;
	}

	public void ChangeVoice(){
		bullet.GetComponent<AudioSource> ().volume = voiceSlider.value;
		bullet2.GetComponent<AudioSource> ().volume = voiceSlider.value;
		mainCamera.GetComponent<AudioSource>().volume = voiceSlider.value;
		Explostion_asteroid.GetComponent<AudioSource> ().volume = voiceSlider.value;
		Explostion_player.GetComponent<AudioSource> ().volume = voiceSlider.value;
		Explostion_enemy.GetComponent<AudioSource> ().volume = voiceSlider.value;
	}
}
