using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;
using ChickenInvaders;
using UnityEngine.Advertisements;


public class FreeCoinRewardUI : MonoBehaviour
{
    public GameObject dailyRewardBtn;

    public Text dailyRewardBtnText;

//	public Text dailyRewardBtnText1;
    public GameObject rewardUI;
    public GameObject rewardUIBG;
    Animator dailyRewardAnimator;
    public static int isFreeAd = 0;
    public Text CountNumAds;
    public Button FreeCoinBtn;

    // Use this for initialization
    void Start()
    {
        dailyRewardAnimator = dailyRewardBtn.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CountNumAds.text = "" + DataManager.Instance.FreeAdNumber;
        if (!DailyRewardController1.Instance.disable && dailyRewardBtn.gameObject.activeSelf)
        {
            if (DailyRewardController1.Instance.CanRewardNow() &&
                AdmobBannerController.Instance.rewardBasedVideo.IsLoaded())
            {
                dailyRewardBtnText.text = "ACTIVE";
                dailyRewardAnimator.SetTrigger("activate");
                FreeCoinBtn.interactable = true;
            }
            else
            {
                TimeSpan timeToReward = DailyRewardController1.Instance.TimeUntilReward;
                dailyRewardBtnText.text = string.Format("{0:00}:{1:00}:{2:00}", timeToReward.Hours,
                    timeToReward.Minutes, timeToReward.Seconds);
                dailyRewardAnimator.SetTrigger("deactivate");
                FreeCoinBtn.interactable = false;
            }

            if (DailyRewardController1.Instance.CanRewardNow() &&
                !AdmobBannerController.Instance.rewardBasedVideo.IsLoaded())
            {
                dailyRewardBtnText.text = "WAIT";
                dailyRewardAnimator.SetTrigger("deactivate");
                FreeCoinBtn.interactable = false;
            }
        }
    }

    public void ShowStartUI()
    {
        ShowDailyRewardBtn();
    }

    void ShowDailyRewardBtn()
    {
        // Not showing the daily reward button if the feature is disabled
        if (!DailyRewardController1.Instance.disable)
        {
            dailyRewardBtn.SetActive(true);
        }
    }

    public void FreeCoinWatchAds()
    {
        if (DailyRewardController1.Instance.CanRewardNow() &&
            (AdmobBannerController.Instance.rewardBasedVideo.IsLoaded()))
        {
            if (DataManager.Instance.FreeAdNumber <= 10 && DataManager.Instance.FreeAdNumber > 0)
            {
                FreeCoinBtn.interactable = false;
                DataManager.Instance.RemoveFreeAdNumber(1);
                //ads
                //GameObject.FindObjectOfType<AdManagerUnity> ().ShowAd ("rewardedVideo");
                AdmobBannerController.Instance.ShowRewardBasedVideo();
                isFreeAd = 1;
            }

            if (DataManager.Instance.FreeAdNumber <= 0)
            {
                DailyRewardController1.Instance.ResetNextRewardTime();
                DataManager.Instance.AddFreeAdNumber(10);
            }
        }
    }

    public void FreeAdsCallBack()
    {
        isFreeAd = 0;
        dailyRewardBtn.SetActive(false);
        FreeCoinBtn.interactable = true;
        float value = UnityEngine.Random.value;
        int reward = DailyRewardController1.Instance.GetRandomRewardCoins();

        // Round the number and make it mutiplies of 5 only.
        int roundedReward = (reward / 5) * 5;
        // Show the reward UI
        ShowRewardUI(roundedReward);
    }


    public void ShowRewardUI(int reward)
    {
        rewardUI.SetActive(true);
        rewardUIBG.SetActive(true);
        rewardUI.GetComponent<RewardUIController>().Reward(reward);

        RewardUIController.RewardUIClosed += OnRewardUIClosed;
    }

    void OnRewardUIClosed()
    {
        RewardUIController.RewardUIClosed -= OnRewardUIClosed;
        dailyRewardBtn.SetActive(true);
    }

    public void HideRewardUI()
    {
        rewardUIBG.SetActive(false);
        rewardUI.GetComponent<RewardUIController>().Close();
//		Debug.Log ("Close");
    }
}