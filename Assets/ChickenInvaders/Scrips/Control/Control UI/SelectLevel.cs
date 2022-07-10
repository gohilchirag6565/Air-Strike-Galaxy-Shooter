using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {

	public Button btn_Exit;
	public Button[] btn_Level;
	public GameObject[] ConnectLV;
	public GameObject panelStart,ImageCheck,SaveZone,EscapeGO;
	int level,lastIndex; 

	// Use this for initialization
	void Start () {
//		PlayerPrefs.SetInt ("TotalLevelDone", 14);
//		PlayerPrefs.DeleteAll();
		btn_Exit.onClick.AddListener (() => OnClickExit ());
		btn_Level[0].onClick.AddListener (() => OnclickButtonLevel (0));
		btn_Level[1].onClick.AddListener (() => OnclickButtonLevel (1));
		btn_Level[2].onClick.AddListener (() => OnclickButtonLevel (2));
		btn_Level[3].onClick.AddListener (() => OnclickButtonLevel (3));
		btn_Level[4].onClick.AddListener (() => OnclickButtonLevel (4));
		btn_Level[5].onClick.AddListener (() => OnclickButtonLevel (5));
		btn_Level[6].onClick.AddListener (() => OnclickButtonLevel (6));
		btn_Level[7].onClick.AddListener (() => OnclickButtonLevel (7));
		btn_Level[8].onClick.AddListener (() => OnclickButtonLevel (8));
		btn_Level[9].onClick.AddListener (() => OnclickButtonLevel (9));
		btn_Level[10].onClick.AddListener (() => OnclickButtonLevel (10));
		btn_Level[11].onClick.AddListener (() => OnclickButtonLevel (11));
		btn_Level[12].onClick.AddListener (() => OnclickButtonLevel (12));
		btn_Level[13].onClick.AddListener (() => OnclickButtonLevel (13));
		btn_Level[14].onClick.AddListener (() => OnclickButtonLevel (14));
		btn_Level[15].onClick.AddListener (() => OnclickButtonLevel (15));
		btn_Level[16].onClick.AddListener (() => OnclickButtonLevel (16));
		btn_Level[17].onClick.AddListener (() => OnclickButtonLevel (17));
		btn_Level[18].onClick.AddListener (() => OnclickButtonLevel (18));
		btn_Level[19].onClick.AddListener (() => OnclickButtonLevel (19));
		btn_Level[20].onClick.AddListener (() => OnclickButtonLevel (20));
		btn_Level[21].onClick.AddListener (() => OnclickButtonLevel (21));
		btn_Level[22].onClick.AddListener (() => OnclickButtonLevel (22));
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnEnable(){
		Music.THIS.GetComponent<AudioSource> ().loop = true;
		Music.THIS.GetComponent<AudioSource> ().clip = Music.THIS.music[1];
		Music.THIS.GetComponent<AudioSource> ().Play ();
		if (PlayerPrefs.GetInt ("TotalLevelDone") == 23)
			lastIndex = 22;
		else 
			lastIndex = PlayerPrefs.GetInt ("TotalLevelDone");
		
		for (int i= 0; i <= lastIndex; i++) {
			btn_Level [i].GetComponent<Button> ().interactable = true;
			if (i > 0)
				ConnectLV [i - 1].SetActive (true);
			if (i < lastIndex) {
				btn_Level [i].transform.GetChild (0).gameObject.SetActive (true);
			}
		}
		ImageCheck.GetComponentInChildren<Text> ().text = lastIndex + 1 + "";

		SaveZone.transform.position = new Vector3 (btn_Level[lastIndex].transform.position.x
			,btn_Level[lastIndex].transform.position.y,0);
	}

	void OnclickButtonLevel(int index){

		btn_Level [lastIndex].transform.GetChild (0).gameObject.SetActive (true);
		btn_Level [index].transform.GetChild (0).gameObject.SetActive (false);
		lastIndex = index;
		ImageCheck.GetComponentInChildren<Text> ().text = index + 1 + "";
		SaveZone.transform.position = new Vector3 (btn_Level[index].transform.position.x
			,btn_Level[index].transform.position.y,0);
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		PlayerPrefs.SetInt ("Level",index);
		panelStart.SetActive (true);
		EscapeGO.SetActive (false);
	}

	void OnClickExit()
	{
		FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.ButtonClick);
		SceneManager.LoadScene ("Main");
	}
}
