using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : MonoBehaviour
{
    public static Ads instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShawBanner()
    {
        
        if (Firebase_Analytics.instance != null)
        {
            Firebase_Analytics.instance.AnalyticsAdsWatch("Banner", "ShowBanner");
        }
        
        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM,BannerType.Adaptive);
    }

    public void ShowInterstitial()
    {
        Advertisements.Instance.ShowInterstitial();
    }
    
}
