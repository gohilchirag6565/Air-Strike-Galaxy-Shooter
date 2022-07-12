using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SocialPlatforms;
#if UNITY_ANDROID
using GooglePlayGames;
#endif

public class LeaderboardController : MonoBehaviour
{
#if UNITY_IOS
	public string LEADERBOARD_BEST_SCORE = "galaxyattack_bestscore";
	public string LEADERBOARD_BEST_LEVELS = "galaxyattack_unlocklevel";
	public string LEADERBOARD_TOTAL_GOLDS = "galaxyattack_totalgold";
	private static LeaderboardController instance;

	public static LeaderboardController Instance
	{
		get{ 
			return instance;
		}
	}
	void Awake()
	{
		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if (instance != this) {
			Destroy (gameObject);
		}
		StartCoroutine(checkInternetConnection((isConnected)=>
			{
			if(isConnected)
			{
				Connect ();	

			}
		}));

	}
	IEnumerator checkInternetConnection(Action<bool> action){
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
			action (false);
		} else {
			action (true);
		}
	} 

	private void Connect() 
	{	
		Social.localUser.Authenticate ((bool success) => 
		{	
				if(success)
				{
					submitbestscore(PlayerPrefs.GetInt ("BestScoreAll"));
					submitlevelunlock(PlayerPrefs.GetInt ("TotalLevelDone"));
					submittotalgold(PlayerPrefs.GetInt ("GOLD"));
				}
					
		});
	}
		
	public void ShowLeaderBoard_iOS() 
	{
		Social.ShowLeaderboardUI ();
		submitbestscore(PlayerPrefs.GetInt ("BestScoreAll"));
		submitlevelunlock(PlayerPrefs.GetInt ("TotalLevelDone"));
		submittotalgold(PlayerPrefs.GetInt ("GOLD"));
	  
	}				

	public void submitbestscore(int score)
	{		
		Social.ReportScore (score, LEADERBOARD_BEST_SCORE, success => {});
	}
	public void submitlevelunlock(int score)
	{		
		Social.ReportScore (score, LEADERBOARD_BEST_LEVELS, success => {});
	}
	public void submittotalgold(int score)
	{		
		Social.ReportScore (score, LEADERBOARD_TOTAL_GOLDS, success => {});
	}


#elif UNITY_ANDROID
    private static LeaderboardController instance;

    public static LeaderboardController Instance
    {
        get { return instance; }
    }

    #region PUBLIC_VAR

    private string leaderboard_hiscore;
    private string leaderboard_unlockmap;
    private string leaderboard_totalcoins;

    #endregion

    #region DEFAULT_UNITY_CALLBACKS

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        leaderboard_hiscore = GPGSIds.leaderboard_highscore;
        leaderboard_unlockmap = GPGSIds.leaderboard_unlock_maps;
        leaderboard_totalcoins = GPGSIds.leaderboard_totalgolds;
        PlayGamesPlatform.Activate();
        this.LogIn();
    }

    #endregion

    #region BUTTON_CALLBACKS

    /// <summary>
    /// Login In Into Your Google+ Account
    /// </summary>
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                //Debug.Log ("Login Sucess");
                OnAddScoreToLeaderBorad();
            }
            else
            {
                //Debug.Log ("Login failed");
            }
        });
    }

    /// <summary>
    /// Shows All Available Leaderborad
    /// </summary>
    public void ShowLeaderBoard_Android()
    {
        OnAddScoreToLeaderBorad();
        OnAddUnlockmapToLeaderBorad();
        OnAddTotalToLeaderBorad();

        Social.ShowLeaderboardUI(); // Show all leaderboard
//		Debug.Log ("ShowLB_Android");
//		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard_hiscore); // Show current (Active) leaderboard
    }

    /// <summary>
    /// Adds Score To leader board
    /// </summary>
    public void OnAddScoreToLeaderBorad()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("BestScoreAll"), leaderboard_hiscore, (bool success) =>
            {
                if (success)
                {
                }
                else
                {
                }
            });
        }
    }

    public void OnAddUnlockmapToLeaderBorad()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("TotalLevelDone"), leaderboard_unlockmap, (bool success) =>
            {
                if (success)
                {
                }
                else
                {
                }
            });
        }
    }

    public void OnAddTotalToLeaderBorad()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("GOLD"), leaderboard_totalcoins, (bool success) =>
            {
                if (success)
                {
                }
                else
                {
                }
            });
        }
    }

    /// <summary>
    /// On Logout of your Google+ Account
    /// </summary>
    public void OnLogOut()
    {
        //((PlayGamesPlatform)Social.Active).SignOut ();
    }

    #endregion

#endif
    public void ShowLeaderBoard()
    {
#if UNITY_IOS
		ShowLeaderBoard_iOS();
#elif UNITY_ANDROID
        ShowLeaderBoard_Android();
#endif
    }
}