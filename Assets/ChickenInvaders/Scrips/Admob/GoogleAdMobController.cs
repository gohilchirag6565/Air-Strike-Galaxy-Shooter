using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

// Test
using GoogleMobileAdsMediationTestSuite.Api;

public class GoogleAdMobController : MonoBehaviour
{
    public static GoogleAdMobController Instance;
    
    private AppOpenAd appOpenAd;
    private BannerView bannerView;
    public InterstitialAd interstitialAd;
    public RewardedAd rewardedAd;
    private RewardedInterstitialAd rewardedInterstitialAd;
    private float deltaTime;
    private bool isShowingAppOpenAd;
    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    public bool showFpsMeter = true;
    //public Text fpsMeter;
    //public Text statusText;


    public RewardedAdsMediation RewardedAdsMediation;
    
    
    public bool useTestAds;    
    
    //Test
    private void ShowMediationTestSuite()
    {
        MediationTestSuite.Show();
    }
    
    
    #region UNITY MONOBEHAVIOR METHODS

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        //else if (Instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(this);
    }

    //Test
    public void HandleMediationTestSuiteDismissed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleMediationTestSuiteDismissed event received");
    }
    
    public void Start()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);

        //Test
        MediationTestSuite.OnMediationTestSuiteDismissed += this.HandleMediationTestSuiteDismissed;
        
        List<String> deviceIds = new List<String>() { AdRequest.TestDeviceSimulator };

        // Add some test device IDs (replace with your own device IDs).
#if UNITY_IPHONE
        deviceIds.Add("70C278A27C5599140A854A09B775FCD0");
#elif UNITY_ANDROID
        deviceIds.Add("70C278A27C5599140A854A09B775FCD0");
#endif

        // Configure TagForChildDirectedTreatment and test device IDs.
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.Unspecified)
            .SetTestDeviceIds(deviceIds).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
        
        //Test
        MediationTestSuite.AdRequest = new AdRequest.Builder().Build();


        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });

        RequestAndLoadRewardedAd();
        RequestAndLoadInterstitialAd();
        
        //Test
        //ShowMediationTestSuite();
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Initialization complete.");

        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // the main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            Debug.Log("Initialization complete.");
            RequestBannerAd();
        });
    }

    private void Update()
    {
        if (showFpsMeter)
        {
            //fpsMeter.gameObject.SetActive(true);
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            Debug.Log(string.Format("{0:0.} fps", fps));
        }
        else
        {
            //fpsMeter.gameObject.SetActive(false);
        }
    }

    #endregion

    #region HELPER METHODS

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .Build();
    }

    public void OnApplicationPause(bool paused)
    {
        // Display the app open ad when the app is foregrounded.
        if (!paused)
        {
            ShowAppOpenAd();
        }
    }

    #endregion

    #region BANNER ADS

    public void RequestBannerAd()
    {
        Debug.Log("Requesting Banner ad.");

        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId;
        if (useTestAds)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }
        else
        {
            // REAL ADS ID
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) =>
        {
            Debug.Log("Banner ad loaded.");
            OnAdLoadedEvent.Invoke();
        };
        bannerView.OnAdFailedToLoad += (sender, args) =>
        {
            Debug.Log("Banner ad failed to load with error: "+args.LoadAdError.GetMessage());
            OnAdFailedToLoadEvent.Invoke();
        };
        bannerView.OnAdOpening += (sender, args) =>
        {
            Debug.Log("Banner ad opening.");
            OnAdOpeningEvent.Invoke();
        };
        bannerView.OnAdClosed += (sender, args) =>
        {
            Debug.Log("Banner ad closed.");
            OnAdClosedEvent.Invoke();
        };
        bannerView.OnPaidEvent += (sender, args) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Banner ad received a paid event.",
                                        args.AdValue.CurrencyCode,
                                        args.AdValue.Value);
            Debug.Log(msg);
        };

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }

    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
        Debug.Log("Requesting Interstitial ad.");

#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId;
        //adUnitId = useTestAds ? "ca-app-pub-3940256099942544/1033173712" : "ca-app-pub-4743633041251613/2097660123";  //   TEST ADS : REAL ADS
        adUnitId = "ca-app-pub-4743633041251613/2097660123";  //   TEST ADS : REAL ADS
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) =>
        {
            Debug.Log("Interstitial ad loaded.");
            OnAdLoadedEvent.Invoke();
        };
        interstitialAd.OnAdFailedToLoad += (sender, args) =>
        {
            Debug.Log("Interstitial ad failed to load with error: "+args.LoadAdError.GetMessage());
            OnAdFailedToLoadEvent.Invoke();
            RequestAndLoadInterstitialAd();
        };
        interstitialAd.OnAdOpening += (sender, args) =>
        {
            Debug.Log("Interstitial ad opening.");
            OnAdOpeningEvent.Invoke();
        };
        interstitialAd.OnAdClosed += (sender, args) =>
        {
            Debug.Log("Interstitial ad closed.");
            OnAdClosedEvent.Invoke();
            RequestAndLoadInterstitialAd();
        };
        interstitialAd.OnAdDidRecordImpression += (sender, args) =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        interstitialAd.OnAdFailedToShow += (sender, args) =>
        {
            Debug.Log("Interstitial ad failed to show.");
            RequestAndLoadInterstitialAd();
        };
        interstitialAd.OnPaidEvent += (sender, args) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Interstitial ad received a paid event.",
                                        args.AdValue.CurrencyCode,
                                        args.AdValue.Value);
            Debug.Log(msg);
        };

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.Log("Interstitial ad is not ready yet.");
            RequestAndLoadInterstitialAd();
        }
    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }

    #endregion

    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
        Debug.Log("Requesting Rewarded ad.");
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId;
        //adUnitId = useTestAds ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-4743633041251613/4532251771";  //   TEST ADS : REAL ADS
        adUnitId = "ca-app-pub-4743633041251613/4532251771";  //   TEST ADS : REAL ADS
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif

        Debug.Log("Reward ad adUnitId   ===>>>>   " + adUnitId);
        
        // create new rewarded ad instance
        rewardedAd = new RewardedAd(adUnitId);

        // Add Event Handlers
        rewardedAd.OnAdLoaded += (sender, args) =>
        {
            Debug.Log("Reward ad loaded.");
            OnAdLoadedEvent.Invoke();
        };
        rewardedAd.OnAdFailedToLoad += (sender, args) =>
        {
            Debug.Log("Reward ad failed to load.");
            OnAdFailedToLoadEvent.Invoke();
            RequestAndLoadRewardedAd();
        };
        rewardedAd.OnAdOpening += (sender, args) =>
        {
            Debug.Log("Reward ad opening.");
            OnAdOpeningEvent.Invoke();
        };
        rewardedAd.OnAdFailedToShow += (sender, args) =>
        {
            Debug.Log("Reward ad failed to show with error: "+args.AdError.GetMessage());
            OnAdFailedToShowEvent.Invoke();
            RequestAndLoadRewardedAd();
        };
        rewardedAd.OnAdClosed += (sender, args) =>
        {
            Debug.Log("Reward ad closed.");
            OnAdClosedEvent.Invoke();
            RequestAndLoadRewardedAd();
        };
        rewardedAd.OnUserEarnedReward += (sender, args) =>
        {
            Debug.Log("User earned Reward ad reward: "+args.Amount);
            OnUserEarnedRewardEvent.Invoke();
            RewardedAdsMediation.OnVideoComplete();
        };
        rewardedAd.OnAdDidRecordImpression += (sender, args) =>
        {
            Debug.Log("Reward ad recorded an impression.");
        };
        rewardedAd.OnPaidEvent += (sender, args) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Rewarded ad received a paid event.",
                                        args.AdValue.CurrencyCode,
                                        args.AdValue.Value);
            Debug.Log(msg);
        };

        // Create empty ad request
        rewardedAd.LoadAd(CreateAdRequest());
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Rewarded ad is not ready yet.");
        }
    }

    public void RequestAndLoadRewardedInterstitialAd()
    {
        Debug.Log("Requesting Rewarded Interstitial ad.");

        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5354046379";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/6978759866";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        RewardedInterstitialAd.LoadAd(adUnitId, CreateAdRequest(), (rewardedInterstitialAd, error) =>
        {
            if (error != null)
            {
                Debug.Log("Rewarded Interstitial ad load failed with error: " + error);
                return;
            }

            this.rewardedInterstitialAd = rewardedInterstitialAd;
            Debug.Log("Rewarded Interstitial ad loaded.");

            // Register for ad events.
            this.rewardedInterstitialAd.OnAdDidPresentFullScreenContent += (sender, args) =>
            {
                Debug.Log("Rewarded Interstitial ad presented.");
            };
            this.rewardedInterstitialAd.OnAdDidDismissFullScreenContent += (sender, args) =>
            {
                Debug.Log("Rewarded Interstitial ad dismissed.");
                this.rewardedInterstitialAd = null;
            };
            this.rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
            {
                Debug.Log("Rewarded Interstitial ad failed to present with error: "+
                                                                        args.AdError.GetMessage());
                this.rewardedInterstitialAd = null;
            };
            this.rewardedInterstitialAd.OnPaidEvent += (sender, args) =>
            {
                string msg = string.Format("{0} (currency: {1}, value: {2}",
                                            "Rewarded Interstitial ad received a paid event.",
                                            args.AdValue.CurrencyCode,
                                            args.AdValue.Value);
                Debug.Log(msg);
            };
            this.rewardedInterstitialAd.OnAdDidRecordImpression += (sender, args) =>
            {
                Debug.Log("Rewarded Interstitial ad recorded an impression.");
            };
        });
    }

    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show((reward) =>
            {
                Debug.Log("Rewarded Interstitial ad Rewarded : " + reward.Amount);
            });
        }
        else
        {
            Debug.Log("Rewarded Interstitial ad is not ready yet.");
        }
    }

    #endregion

    #region APPOPEN ADS

    public void RequestAndLoadAppOpenAd()
    {
        Debug.Log("Requesting App Open ad.");
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/3419835294";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/5662855259";
#else
        string adUnitId = "unexpected_platform";
#endif
        // create new app open ad instance
        AppOpenAd.LoadAd(adUnitId, ScreenOrientation.Portrait, CreateAdRequest(), (appOpenAd, error) =>
        {
            if (error != null)
            {
                Debug.Log("App Open ad failed to load with error: " + error);
                return;
            }

            Debug.Log("App Open ad loaded. Please background the app and return.");
            this.appOpenAd = appOpenAd;
        });
    }

    public void ShowAppOpenAd()
    {
        if (isShowingAppOpenAd)
        {
            return;
        }
        if (appOpenAd == null)
        {
            return;
        }

        // Register for ad events.
        this.appOpenAd.OnAdDidDismissFullScreenContent += (sender, args) =>
        {
            Debug.Log("App Open ad dismissed.");
            isShowingAppOpenAd = false;
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                if (this.appOpenAd != null)
                {
                    this.appOpenAd.Destroy();
                    this.appOpenAd = null;
                }
            });
        };
        this.appOpenAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
        {
            Debug.Log("App Open ad failed to present with error: " + args.AdError.GetMessage());

            isShowingAppOpenAd = false;
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                if (this.appOpenAd != null)
                {
                    this.appOpenAd.Destroy();
                    this.appOpenAd = null;
                }
            });
        };
        this.appOpenAd.OnAdDidPresentFullScreenContent += (sender, args) =>
        {
            Debug.Log("App Open ad opened.");
            isShowingAppOpenAd = true;
        };
        this.appOpenAd.OnAdDidRecordImpression += (sender, args) =>
        {
            Debug.Log("App Open ad recorded an impression.");
        };
        this.appOpenAd.OnPaidEvent += (sender, args) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "App Open ad received a paid event.",
                                        args.AdValue.CurrencyCode,
                                        args.AdValue.Value);
            Debug.Log(msg);
        };
        appOpenAd.Show();
    }

    #endregion


    #region AD INSPECTOR

    public void OpenAdInspector()
    {
        Debug.Log("Open ad Inspector.");

        MobileAds.OpenAdInspector((error) =>
        {
            if (error != null)
            {
                Debug.Log("ad Inspector failed to open with error: " + error);
            }
            else
            {
                Debug.Log("Ad Inspector opened successfully.");
            }
        });
    }

    #endregion

    #region Utility

    ///<summary>
    /// Log the message and update the status text on the main thread.
    ///<summary>
    /*private void Debug.Log(string message)
    {
        Debug.Log(message);
        MobileAdsEventExecutor.ExecuteInUpdate(() => {
            Debug.Log(message);
        });
    }*/

    #endregion
    
}