using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayScenes : MonoBehaviour {
	public Button btn_Pause;
	public GameObject Player_Ingame, panel_Pause;
	public static int CheckPaused;
	// Use this for initialization
	void Start () {
		btn_Pause.onClick.AddListener (() => PauseGame ());
	}
	void Update () {
	
	}

	void UpLevel()
	{
		Player_Ingame.transform.position = new Vector3(0, -3f,0);
		Player_Ingame.SetActive(true);
	}

	void ChangeStype(){
		if (Player.instance.numberStypeLast == 0)
			Player.instance.ChangeStypeGun (1);
		else if (Player.instance.numberStypeLast == 1)
			Player.instance.ChangeStypeGun (2);
		else if (Player.instance.numberStypeLast == 2)
			Player.instance.ChangeStypeGun (0);
	}

	void PauseGame()
	{
		AdmobBannerController.Instance.ShowBanner ();
		CheckPaused = 1;
		Music.THIS.GetComponent<AudioSource> ().Stop ();
		FXSound.THIS.GetComponent<AudioSource> ().Stop ();
		GameObject.FindObjectOfType<FXSound> ().GetComponent<AudioSource> ().Stop();
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		Time.timeScale = 0;
		panel_Pause.SetActive (true);
	}
}
