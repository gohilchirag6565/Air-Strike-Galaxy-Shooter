using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UnhideChickenMain : MonoBehaviour {
	public GameObject[] chicken;
	public Button EndlessBtn; 
	public int checklevelUnlock;
	public GameObject UnlockGameObj;
	public GameObject SpinWheelObj;
	public Text GoldText;
	public GameObject VibrateOnObj;
	public GameObject VibrateOffObj;
	public static int CheckVibrate;
	void Start () {
//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("TotalLevelDone",22);
		checklevelUnlock = PlayerPrefs.GetInt ("TotalLevelDone");
		if (checklevelUnlock >= 4) {
			EndlessBtn.interactable = true;
			UnlockGameObj.SetActive (false);
		} else {
			EndlessBtn.interactable = false;
			UnlockGameObj.SetActive (true);
		}
		Time.timeScale = 1;
		StartCoroutine (Wait(0));

		Music.THIS.GetComponent<AudioSource> ().Stop ();
		Music.THIS.GetComponent<AudioSource> ().loop = true;
		Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[0];
		Music.THIS.GetComponent<AudioSource> ().Play ();
		CheckVibrate = 1;
	}

	IEnumerator Wait(int index)
	{

		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ChickenFly);
		yield return new WaitForSeconds (0.05f);
		if (index < chicken.Length - 1) {
			StartCoroutine(Wait (index+1));
		}
		chicken [index].SetActive (true);	
	}

	void Update()
	{
		GoldText.text="GOLD: "+PlayerPrefs.GetInt ("GOLD");
		if (CheckVibrate == 1) {
			VibrateOnObj.SetActive (true);
			VibrateOffObj.SetActive (false);
		} else {
			VibrateOnObj.SetActive (false);
			VibrateOffObj.SetActive (true);
		}
	}
	public void OpenSpinWheel()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SpinWheelObj.SetActive (true);
	}
	public void CloseSpinWheel()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SpinWheelObj.SetActive (false);
	}
	public void ShowLB()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);

		GameObject.FindObjectOfType<LeaderboardController> ().ShowLeaderBoard ();
	}

	public void QuitGame()
	{
		Application.Quit ();
//		Debug.Log ("Quit Game");
	}
	public void VibrateOn()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		VibrateOnObj.SetActive (true);
		VibrateOffObj.SetActive (false);
		CheckVibrate = 1;
	}
	public void VibrateOff()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		VibrateOnObj.SetActive (false);
		VibrateOffObj.SetActive (true);
		CheckVibrate = 0;
	}
}
