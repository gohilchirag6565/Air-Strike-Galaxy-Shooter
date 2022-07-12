using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardedAdsMediation : MonoBehaviour
{
    public UnityEvent OnRewarded;

    public GoogleAdMobController GoogleAdMobController;

    [Space(20)]
    public bool CheckAdsForObject;

    public bool becameIntractable;
    public bool becameDisable;
    public GameObject ObjectRef;
    
    private void Update()
    {
        if(GoogleAdMobController == null)
            GoogleAdMobController = GoogleAdMobController.Instance;

        if (CheckAdsForObject)
        {
            if(becameIntractable)
                ObjectRef.GetComponent<Button>().interactable = (GoogleAdMobController.rewardedAd.IsLoaded());
            else if(becameDisable)
                ObjectRef.SetActive(GoogleAdMobController.rewardedAd.IsLoaded());
        }
    }

    public void SetReferences()
    {
        if(GoogleAdMobController == null)
            GoogleAdMobController = GoogleAdMobController.Instance;
        
        GoogleAdMobController.Instance.RewardedAdsMediation = this;
    }
    
    public void OnVideoComplete()
    {
        StartCoroutine(WaitFewSecond());
    }
    
    private IEnumerator WaitFewSecond()
    {
        yield return new WaitForSeconds(0.1f);
        OnRewarded.Invoke();
    }
}
