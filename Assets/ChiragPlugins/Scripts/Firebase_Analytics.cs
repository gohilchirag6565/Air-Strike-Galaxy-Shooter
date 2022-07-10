using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Firebase_Analytics : MonoBehaviour
{
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    public bool firebaseInitialized = false;

    public static Firebase_Analytics instance;
 
    public static Dictionary<string, string> AdsIdData = new Dictionary<string, string>();

    private AdsIDScripts _adsIDScripts;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        
        if(_adsIDScripts == null)
            _adsIDScripts = this.GetComponent<AdsIDScripts>();
    }
    
    public virtual void Start()
    {
        /*FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                    "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });*/
    }

    void InitializeFirebase()
    {
        Debug.Log("Enabling data collection.");
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        firebaseInitialized = true;
        AnalyticsLogin();
        
        
        // For ADs
        // [START set_defaults]
        System.Collections.Generic.Dictionary<string, object> defaults =
            new System.Collections.Generic.Dictionary<string, object>();

        /*Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults);*/
        // [END set_defaults]
        Debug.Log("RemoteConfig configured and ready!");

        FetchDataAsync();
    }
    
    public Task FetchDataAsync()
    {
        Debug.Log("Fetching data...");
        /*System.Threading.Tasks.Task fetchTask = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(
            TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);*/
        return null;
    }
    
    void FetchComplete(Task fetchTask)
    {
        if (fetchTask.IsCanceled)
        {
            Debug.Log("Fetch canceled.");
        }
        else if (fetchTask.IsFaulted)
        {
            Debug.Log("Fetch encountered an error.");
        }
        else if (fetchTask.IsCompleted)
        {
            Debug.Log("Fetch completed successfully!");
        }

        var info = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.Info;
        switch (info.LastFetchStatus)
        {
            case Firebase.RemoteConfig.LastFetchStatus.Success:
                /*Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
                    .ContinueWithOnMainThread(task =>
                    {
                        Debug.Log(String.Format("Remote data loaded and ready (last fetch time {0}).",
                            info.FetchTime));
                    });*/
                Debug.Log(String.Format("Remote data loaded and ready (last fetch time {0}).",
                    info.FetchTime));

                DisplayAllKeys();

                break;
            case Firebase.RemoteConfig.LastFetchStatus.Failure:
                /*switch (info.LastFetchFailureReason)
                {
                    case Firebase.RemoteConfig.FetchFailureReason.Error:
                        Debug.Log("Fetch failed for unknown reason");
                        break;
                    case Firebase.RemoteConfig.FetchFailureReason.Throttled:
                        Debug.Log("Fetch throttled until " + info.ThrottledEndTime);
                        break;
                }*/

                break;
            case Firebase.RemoteConfig.LastFetchStatus.Pending:
                Debug.Log("Latest Fetch call still pending.");
                break;
        }
    }
    
    public void DisplayAllKeys()
    {
        Debug.Log("Current Keys:");

        /*var settings = Firebase.RemoteConfig.FirebaseRemoteConfig.Settings;
        settings.IsDeveloperMode = true;
        Firebase.RemoteConfig.FirebaseRemoteConfig.Settings = settings;*/

        System.Collections.Generic.IEnumerable<string> keys = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance
            .Keys;
        foreach (string key in keys)
        {
            var _value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(key).StringValue;
            //Debug.Log("HIIIIII   key => " + key + "  \n Value => " + _value);

            AdsIdData.Add(key, _value);

            if (key.Equals("android_banner_id"))
                _adsIDScripts.Admob_id_Banner = _value;
            else if (key.Equals("android_interstitial_id"))
                _adsIDScripts.Admob_id_Interstitial = _value;
            else if (key.Equals("android_rewarded_id"))
                _adsIDScripts.Admob_id_Rewarded = _value;
        }

        ///******************************
        /// Start INIT all ads network
        ///****************************** 

        StartCoroutine(_adsIDScripts.InitAllAds());
    }
    
    
    public void AnalyticsCustomLinkOpen(string buttonName)
    {
        // Log an event with an int parameter.

        FirebaseAnalytics.LogEvent("MainScreen","LinkOpen", buttonName);
    }
    

    public void AnalyticsLogin()
    {
        // Log an event with no parameters.
        Debug.Log("Logging a login event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
    }

    public void AnalyticsGameOverScore(int score)
    {
        // Log an event with an int parameter.

        FirebaseAnalytics.LogEvent("LevelFailed","GameOver", score);
    }

    
    public void AnalyticsAdsWatch(string adType,string location)
    {
        // Log an event with an int parameter.
       
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.ParameterAdFormat, adType, location);
    }

    public Task<string> DisplayAnalyticsInstanceId()
    {
        /*return FirebaseAnalytics.GetAnalyticsInstanceIdAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("App instance ID fetch was canceled.");
            }
            else if (task.IsFaulted)
            {
                Debug.Log(String.Format("Encounted an error fetching app instance ID {0}",
                    task.Exception.ToString()));
            }
            else if (task.IsCompleted)
            {
                Debug.Log(String.Format("App instance ID: {0}", task.Result));
            }

            return task;
        }).Unwrap();*/

        return null;
    }
}