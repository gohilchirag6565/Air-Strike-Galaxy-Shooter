using ChiragMobileAds;

namespace ChiragAds
{
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.Events;
#if USE_APPLOVIN
    using System.Linq;
#endif

    public class CustomAppLovin : MonoBehaviour, ICustomAds
    {
        //dummy interface implementation, used when AppLovin is not enabled
        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
        }


        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
        }


        public bool IsBannerAvailable()
        {
            return false;
        }


        public void ShowBanner(BannerPosition position, BannerType type,
            UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {
        }


        public void HideBanner()
        {
        }


        public void ResetBannerUsage()
        {
        }


        public bool BannerAlreadyUsed()
        {
            return false;
        }


        public bool IsInterstitialAvailable()
        {
            return false;
        }


        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
        }


        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
        }


        public bool IsRewardVideoAvailable()
        {
            return false;
        }


        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
        }


        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
        }
    }
}