using ChiragMobileAds;

namespace ChiragAds
{
    using UnityEngine.Events;
    using System.Collections.Generic;
    using UnityEngine;
#if USE_VUNGLE
    using System.Linq;
    using System.Collections;
#endif

    public class CustomVungle : MonoBehaviour, ICustomAds
    {
        //dummy interface implementation, used when Vungle is not enabled
        public void HideBanner()
        {
        }

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent, List<PlatformSettings> platformSettings)
        {
        }

        public void ResetBannerUsage()
        {
        }

        public bool BannerAlreadyUsed()
        {
            return false;
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

        public void ShowBanner(BannerPosition position, BannerType type,
            UnityAction<bool, BannerPosition, BannerType> DisplayResult)
        {
        }

        public void ShowInterstitial(UnityAction InterstitialClosed = null)
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