using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;
using ChickenInvaders;
using UnityEngine.Advertisements;

public class DailyRewardUI : MonoBehaviour
{

    public GameObject dailyRewardBtn;
    public Text dailyRewardBtnText;
    public GameObject rewardUI;
	public GameObject rewardUIBG;
    Animator dailyRewardAnimator;
	public Button DailyRewardBtn;

    // Use this for initialization
    void Start()
    {
//		TextCoinObj.SetActive (false);
		dailyRewardAnimator = dailyRewardBtn.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!DailyRewardController.Instance.disable && dailyRewardBtn.gameObject.activeSelf)
        {
            if (DailyRewardController.Instance.CanRewardNow())
            {
				
                if(AdmobBannerController.Instance.rewardBasedVideo.IsLoaded())
                    dailyRewardBtnText.text = "CLAIM";
                dailyRewardAnimator.SetTrigger("activate");
                DailyRewardBtn.interactable = true;

            }
            else
            {
                dailyRewardBtnText.text = "WAIT";
                dailyRewardAnimator.SetTrigger("deactivate");
                DailyRewardBtn.interactable = false;
            }

            /*
            if (Advertisement.IsReady ("rewardedVideo")) {
					dailyRewardBtnText.text = "CLAIM";
					dailyRewardAnimator.SetTrigger ("activate");
					DailyRewardBtn.interactable = true;
					
				} else
				{
					dailyRewardBtnText.text = "WAIT";
					dailyRewardAnimator.SetTrigger ("deactivate");
					DailyRewardBtn.interactable = false;
                    }
				*/
            }
            else
            {
                TimeSpan timeToReward = DailyRewardController.Instance.TimeUntilReward;
                dailyRewardBtnText.text = string.Format("{0:00}:{1:00}:{2:00}", timeToReward.Hours, timeToReward.Minutes, timeToReward.Seconds);
                dailyRewardAnimator.SetTrigger("deactivate");
				DailyRewardBtn.interactable = false;
            }
        }

    

    public void ShowStartUI()
    {
        ShowDailyRewardBtn();
    }

    void ShowDailyRewardBtn()
    {
        // Not showing the daily reward button if the feature is disabled
        if (!DailyRewardController.Instance.disable)
        {
            dailyRewardBtn.SetActive(true);
        }
    }

    public void GrabDailyReward()
    {
		
		if (DailyRewardController.Instance.CanRewardNow () && AdmobBannerController.Instance.rewardBasedVideo.IsLoaded() /*Advertisement.IsReady ("rewardedVideo")*/) 
		{

			dailyRewardBtn.SetActive (false);
			float value = UnityEngine.Random.value;
			int reward = DailyRewardController.Instance.GetRandomRewardCoins ();

			// Round the number and make it mutiplies of 5 only.
			int roundedReward = (reward / 5) * 5;
			// Show the reward UI
			ShowRewardUI (roundedReward);

			// Update next time for the reward
			DailyRewardController.Instance.ResetNextRewardTime ();
		} 
		else
			FXSound.THIS.fxSound.PlayOneShot (FXSound.THIS.DisActiveBtn);
    }
    public void ShowRewardUI(int reward)
    {
        rewardUI.SetActive(true);
		rewardUIBG.SetActive (true);
        rewardUI.GetComponent<RewardUIController>().Reward(reward);

        RewardUIController.RewardUIClosed += OnRewardUIClosed;
    }

    void OnRewardUIClosed()
    {
        RewardUIController.RewardUIClosed -= OnRewardUIClosed;
        dailyRewardBtn.SetActive(true);
		//ads
//		AdmobBannerController.Instance.ShowInterstitial ();
//		Debug.Log ("DailyClose");
    }

    public void HideRewardUI()
    {
		rewardUIBG.SetActive (false);
        rewardUI.GetComponent<RewardUIController>().Close();
//		Debug.Log ("DailyClose");
    }

}
