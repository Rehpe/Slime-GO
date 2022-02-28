using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour
{
    public static adsManager I;

    string adType;
    string gameId;
    public int adCounts;

    void Awake()
    {
        I = this;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adType = "Rewarded_iOS";
            gameId = "4430070"; // 내 iOS 게임아이디

        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "4430071"; // 내 안드로이드 게임아이디
        }

        Advertisement.Initialize(gameId, true);
    }

    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
                ShowOptions options = new ShowOptions { resultCallback = ResultAds };
                Advertisement.Show(adType, options);
                adCounts = 0;
        }
    }
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady())
        {
            if (adCounts >= 2)
            {
                ShowOptions options = new ShowOptions { resultCallback = ResultAds };
                Advertisement.Show("Interstitial_Android", options);
                adCounts = 0;
            }

            else
            {
                Debug.Log("adCounts가 2 이상이어야 광고가 실행됩니다");
            }

        }
    }



    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("광고 보기에 실패했습니다.");
                break;
            case ShowResult.Skipped:
                Debug.Log("광고를 스킵했습니다.");
                break;
            case ShowResult.Finished:
                // 광고 보기 보상 기능 
                /*gameManager.I.retry();*/
                break;
        }
    }
}