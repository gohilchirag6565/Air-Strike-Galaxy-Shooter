using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollMain : MonoBehaviour {

	ScrollRect scroll;
	bool LerpV = true;

	// Use this for initialization
	void Start ()
	{
		scroll = gameObject.GetComponent<ScrollRect>();
		scroll.inertia = false;
	}

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButton();
        }

        if (LerpV)
		{
			if (PlayerPrefs.GetInt ("TotalLevelDone")>2)
				scroll.verticalNormalizedPosition = (float)(PlayerPrefs.GetInt ("TotalLevelDone")-1) / 23;
			LerpV = false;
			scroll.inertia = true;
		}
	}


    public void OnBackButton()
    {
        Debug.Log("sceme " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Map_Level")
        {
            FXSound.THIS.fxSound.PlayOneShot(FXSound.THIS.ButtonClick);
            SceneManager.LoadScene("Main");
            TrackingSceneController.THIS.gameState = GameState.HomeScene;
        }
    }

}