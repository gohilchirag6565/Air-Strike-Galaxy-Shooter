using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
	public Button btn_Yes,btn_No;
	public GameObject panel_Exit,GameObjectMain;

	// Use this for initialization
	void Start () {
		btn_Yes.onClick.AddListener (() => OnClick_Yes ());
		btn_No.onClick.AddListener (() => OnClick_No ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick_Yes()
	{
		Application.Quit ();
	}

	void OnClick_No()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
//		SoundManager.Sound.Sound_ClickButton ();
		panel_Exit.SetActive (false);
		GameObjectMain.SetActive (true);
	}
}
