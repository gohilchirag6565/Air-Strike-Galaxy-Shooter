using ChiragMobileAds;

namespace ChiragAds
{
#if USE_IRONSOURCE
    using System.Linq;
    using System.Collections;
#endif
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;


    public class CustomIronSource : MonoBehaviour, ICustomAds
    {
        public bool BannerAlreadyUsed()
        {
            return false;
        }

        public void HideBanner()
        {
        }

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
        }

        public bool IsBannerAvailable()
        {
            return false;
        }

        public bool IsInterstitialAvailable()
        {
            return false;
        }

        public bool IsRewardVideoAvailable()
        {
            return false;
        }

        public void ResetBannerUsage()
        {
        }

        public void ShowBanner(BannerPosition position, BannerType bannerType,
            UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {
        }

        public void ShowInterstitial(UnityAction InterstitialClosed)
        {
        }

        public void ShowInterstitial(UnityAction<string> InterstitialClosed)
        {
        }

        public void ShowRewardVideo(UnityAction<bool> CompleteMethod)
        {
        }

        public void ShowRewardVideo(UnityAction<bool, string> CompleteMethod)
        {
        }

        public void UpdateConsent(UserConsent consent, UserConsent ccpaConsent)
        {
        }
    }
}