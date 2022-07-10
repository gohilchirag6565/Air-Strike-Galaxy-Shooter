using UnityEngine;
using System.Collections;
//#if  GOOGLE_MOBILE_ADS
using GoogleMobileAds.Api;
//#endif
using System;
using UnityEngine.Advertisements;

public class AdmobBannerController : MonoBehaviour 
{
//	#if  GOOGLE_MOBILE_ADS
	private static AdmobBannerController instance;
	public static AdmobBannerController Instance{
		get{ 
			return instance;
		}
	}
	private BannerView bannerView;
	private InterstitialAd interstitial;
    public RewardedAd rewardBasedVideo;

    //Insert your ads id here


#if UNITY_IOS
	public string Admob_Interstitial_ID = "";
	public string Admob_Banner_ID = "";
#elif UNITY_ANDROID
    private string Admob_Interstitial_ID = "ca-app-pub-4743633041251613/6636815178";
    private string Admob_Banner_ID = "ca-app-pub-4743633041251613/3080713546";
	#endif
	public void Awake() {		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if (instance != this) {
			Destroy (gameObject);
		}
		this.RequestInterstitial ();
		this.RequestBanner ();
		this.ShowBanner ();
        InitRewardedVideo();
        RequestRewardBasedVideo();
    }

    private void InitRewardedVideo()
    {
        // Get singleton reward based video ad reference.
        //this.rewardBasedVideo = rewardBasedVideo.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
        //this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
        this.rewardBasedVideo.OnUserEarnedReward += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
        //this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
    }

    public void DestroyBanner(){
		if (this.bannerView != null) 
		{
//			Debug.Log ("Destroy Banner");
			this.bannerView.Destroy ();
		}
	}

    public void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4743633041251613/1192916809";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "unexpected_platform";
#endif

       // this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void ShowBanner()
	{
		this.RequestBanner ();
		if (this.bannerView != null) 
		{
			this.RequestBanner ();
			this.bannerView.Show ();
//			Debug.Log ("Show Banner");
		}
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest CreateAdRequest() {
		return new AdRequest.Builder().Build();
	}
	public void RequestBanner() {
		if (this.bannerView == null) {
			this.bannerView = new BannerView (Admob_Banner_ID, AdSize.SmartBanner, AdPosition.Bottom);
			// Register for ad events.
			this.bannerView.OnAdLoaded += this.HandleAdLoaded;
			this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
			this.bannerView.OnAdOpening += this.HandleAdOpened;
			this.bannerView.OnAdClosed += this.HandleAdClosed;
			//this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

			// Load a banner ad.
			this.bannerView.LoadAd (this.CreateAdRequest ());
//			this.HideBanner ();
		}
	}
	public void RequestInterstitial() {
		this.interstitial = new InterstitialAd(Admob_Interstitial_ID);
		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		//this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		this.interstitial.LoadAd(this.CreateAdRequest());
	}


	public void ShowInterstitial() 
	{
		if (this.interstitial != null) {
			if (this.interstitial.IsLoaded ()) 
			{
				this.interstitial.Show ();
				RequestInterstitial ();
//				Debug.Log ("Show FullBanner");
			}
		}
	}

    public void ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
        else
        {
            MonoBehaviour.print("Reward based video ad is not ready yet");
            AdManagerUnity.ads.ShowAd("rewardedVideo");
            RequestRewardBasedVideo();
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLoaded event received");
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.LoadAdError);
	}

	public void HandleAdOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdOpened event received");
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleAdLeftApplication event received");
	}

	#endregion

	#region Interstitial callback handlers

	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialLoaded event received");
	}

	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print(
			"HandleInterstitialFailedToLoad event received with message: " + args.LoadAdError);
	}

	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialOpened event received");
	}

	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialClosed event received");
	}

	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleInterstitialLeftApplication event received");
	}

    #endregion
    //	#endif

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: " + args.LoadAdError);

        Debug.Log("I swear this has never happened to me before");
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestRewardBasedVideo();
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        Debug.Log("Ad skipped. Son, I am dissapointed in you");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);

        if (I2.MiniGames.PrizeWheel.checkFreeSpinInt == 1)
        {
            GameObject.FindObjectOfType<I2.MiniGames.PrizeWheel>().SpinningCallBackAfterWatchVideoAds();
        }
        if (FreeCoinRewardUI.isFreeAd == 1)
        {
            GameObject.FindObjectOfType<FreeCoinRewardUI>().FreeAdsCallBack();
        }
        if (Defeat.isTakeHeath == 1)
        {
            GameObject.FindObjectOfType<Defeat>().CallBackAfterWatchUnityAds();
        }

    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion
}

