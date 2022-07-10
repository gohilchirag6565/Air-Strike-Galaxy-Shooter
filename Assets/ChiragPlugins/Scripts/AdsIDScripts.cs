using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AdsIDScripts : MonoBehaviour
{
    public static AdsIDScripts Instance;
    
    // Admob
    public string Admob_id_Interstitial;
    public string Admob_id_Banner;
    public string Admob_id_Rewarded;
    
    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator InitAllAds()
    {
        yield return new WaitForSeconds(0.2f);
        Advertisements.Instance.Initialize();
        yield return new WaitForSeconds(0.2f);
        Ads.instance.ShawBanner();
    }
    
}
