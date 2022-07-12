using ChiragMobileAds;

namespace ChiragAds
{
    using UnityEngine;
    using UnityEngine.Events;
#if USE_HEYZAP
    using System.Collections.Generic;
    using System.Linq;
    using Heyzap;
#endif


    public class CustomHeyzap : MonoBehaviour, ICustomAds
    {
        //dummy interface implementation, used when Heyzap is not enabled
        public void HideBanner()
        {
        }

        public void InitializeAds(UserConsent consent, UserConsent ccpaConsent,
            System.Collections.Generic.List<PlatformSettings> platformSettings)
        {
        }

        public bool IsBannerAvailable()
        {
            return false;
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