using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseInGame : MonoBehaviour {
	public Button btn_Resume, btn_Home, btn_Quit;
	public GameObject panel_Pause;

	// Use this for initialization
	void Start () {
		FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		btn_Resume.onClick.AddListener (() => OnClick_Resume ());
		btn_Home.onClick.AddListener (() => OnClick_Home ());
		btn_Quit.onClick.AddListener (() => OnClick_Quit ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick_Resume()
	{
		AdmobBannerController.Instance.DestroyBanner ();
		PlayScenes.CheckPaused = 0;
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		Time.timeScale = 1;
		Music.THIS.GetComponent<AudioSource> ().Play ();
		FXSound.THIS.GetComponent<AudioSource> ().Play ();
		GameObject.FindObjectOfType<FXSound> ().GetComponent<AudioSource> ().Play();
		panel_Pause.SetActive (false);
	}

	void OnClick_Home()
	{
		Time.timeScale = 1;
		PlayScenes.CheckPaused = 0;
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		if (TrackingSceneController.THIS.gameState == GameState.AdventureScene) {
			SceneManager.LoadScene ("Map_Level");
			TrackingSceneController.THIS.gameState = GameState.BeforeStart;
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		}
		else if(TrackingSceneController.THIS.gameState == GameState.EndlessScene)
		{
			SceneManager.LoadScene ("Main");
			TrackingSceneController.THIS.gameState = GameState.HomeScene;
			FXSound.THIS.GetComponent<AudioSource> ().Stop ();
			GameObject.FindObjectOfType<FXSound> ().GetComponent<AudioSource> ().Stop();
		}

	}

	void OnClick_Quit()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		GameObject.FindObjectOfType<LeaderboardController> ().ShowLeaderBoard ();
//		Time.timeScale = 1;

//		Debug.Log ("Ranking");
	}
}
