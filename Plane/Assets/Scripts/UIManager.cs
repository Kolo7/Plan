using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
	public Button startButton;
	public GameObject panel;
	public GameObject rankImage;
	public Text oneText;
	public Text twoText;
	public Text threeText;
	public Text fourText;
	public Text fiveText;

	public Text socreText;
	public int socre;
	public Button stopButton;
	public GameObject pausePanel;
	private bool pausePanelStatus;
	public Slider voiceSlider;
	public Slider backgroundSlider;
	public Slider bulletSlider;
	public Slider explostionSlider;
	public GameObject successUI;
	public GameObject failUI;
	public GameObject dieUI;
	public GameObject voiceUI;

	public GameObject mainCamera;
	public GameObject bullet;
	public GameObject bullet2;
	public GameObject Explostion_asteroid;
	public GameObject Explostion_player;
	public GameObject Explostion_enemy;

	public static int[] rank = new int[6];
	private static int rankLength = 0;
	// Use this for initialization
	void Start(){
		if (SceneManager.GetActiveScene ().name == "plane") {
			pausePanelStatus = false;
			ContinueGame ();
		}
	}
	public void StartGame()
	{
		
		SceneManager.LoadScene("scene");

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

	public void ChangeBulletVoice(){
		bullet.GetComponent<AudioSource> ().volume = bulletSlider.value;
		bullet2.GetComponent<AudioSource> ().volume = bulletSlider.value;
	}
	public void ChangeExplostionVoice(){
		Explostion_asteroid.GetComponent<AudioSource> ().volume = explostionSlider.value;
		Explostion_player.GetComponent<AudioSource> ().volume = explostionSlider.value;
		Explostion_enemy.GetComponent<AudioSource> ().volume = explostionSlider.value;
	}

	public void ChangeBackgroundVoice(){
		mainCamera.GetComponent<AudioSource>().volume = backgroundSlider.value;
	}

	public void Success(){
		dieUI.SetActive (true);
		if (rankLength > 0 && socre < rank [rankLength - 1])
			failUI.SetActive (true);
		else
			successUI.SetActive (true);				
	}

	public void AddRank(){
		if (rankLength < 5)
			rank [rankLength++] = socre;
		else
			rank [rankLength] = socre;
		System.Array.Sort (rank);
		System.Array.Reverse(rank);
		for (int i = 0; i < rankLength; i++) {
			Debug.Log (rank[i]);
		}
	}

	public void LookRank(){
		Debug.Log ("rank");
		rankImage.SetActive (true);
		oneText.text = rank [0].ToString();
		twoText.text = rank [1].ToString();
		threeText.text = rank [2].ToString();
		fourText.text = rank [3].ToString();
		fiveText.text = rank [4].ToString();
	}

	public void LookVoicePanel(){
		voiceUI.SetActive (true);
	}

	public void CloseVoicePanel(){
		voiceUI.SetActive (false);
	}
	public void closeRank(){
		rankImage.SetActive (false);
	}

	public void AgainGame(){
		dieUI.SetActive (false);
		SceneManager.LoadScene("plane");
	}
	public void GameOver(){
		Application.Quit();
	}
}
