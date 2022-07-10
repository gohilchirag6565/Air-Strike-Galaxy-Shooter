#if DISABLE


using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defective.JSON;
using Firebase;
using UnityEngine;

public class FirebaseInitializer : MonoBehaviour
{
    //public GUISkin fb_GUISkin;
    private Vector2 controlsScrollViewVector = Vector2.zero;
    private Vector2 scrollViewVector = Vector2.zero;
    bool UIEnabled = true;
    private string logText = "";
    const int kMaxLogSize = 16382;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    protected bool isFirebaseInitialized = false;

    

    void Start()
    {
      
        Debug.Log("===>>>>  " + this.gameObject.name);
        StartCoroutine(StartInit());
    }

    IEnumerator StartInit()
    {
        var i = GetComponent<Firebase_Analytics>().firebaseInitialized ? 1 : 0;
        yield return new WaitUntil(() => i == 1);
        
        InitializeFirebase();
        
        /*Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
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

    // Initialize remote config, and set the default values.
    void InitializeFirebase()
    {
        
    }

    public void DisplayData()
    {
        /*DebugLog("Current Data:");
        DebugLog("config_test_string: " +
                 Firebase.RemoteConfig.FirebaseRemoteConfig.GetValue("config_test_string").StringValue);
        DebugLog("config_test_int: " +
                 Firebase.RemoteConfig.FirebaseRemoteConfig.GetValue("config_test_int").LongValue);
        DebugLog("config_test_float: " +
                 Firebase.RemoteConfig.FirebaseRemoteConfig.GetValue("config_test_float").DoubleValue);
        DebugLog("config_test_bool: " +
                 Firebase.RemoteConfig.FirebaseRemoteConfig.GetValue("config_test_bool").BooleanValue);*/
    }

    


    
    //[END fetch_async]

   


    // Output text to the debug log text field, as well as the console.
    public void DebugLog(string s)
    {
        print(s);
        logText += s + "\n";

        while (logText.Length > kMaxLogSize)
        {
            int index = logText.IndexOf("\n");
            logText = logText.Substring(index + 1);
        }

        scrollViewVector.y = int.MaxValue;
    }

    void DisableUI()
    {
        UIEnabled = false;
    }

    void EnableUI()
    {
        UIEnabled = true;
    }

    // Render the log output in a scroll view.
    void GUIDisplayLog()
    {
        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        GUILayout.Label(logText);
        GUILayout.EndScrollView();
    }

    // Render the buttons and other controls.
    void GUIDisplayControls()
    {
        if (UIEnabled)
        {
            controlsScrollViewVector =
                GUILayout.BeginScrollView(controlsScrollViewVector);
            GUILayout.BeginVertical();
            if (GUILayout.Button("Display Current Data"))
            {
                DisplayData();
            }

            if (GUILayout.Button("Display All Keys"))
            {
                DisplayAllKeys();
            }

            if (GUILayout.Button("Fetch Remote Data"))
            {
                FetchDataAsync();
            }

            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }
    }
}

#endif