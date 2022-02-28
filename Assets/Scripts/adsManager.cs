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
            gameId = "4430070"; // �� iOS ���Ӿ��̵�

        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "4430071"; // �� �ȵ���̵� ���Ӿ��̵�
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
                Debug.Log("adCounts�� 2 �̻��̾�� ���� ����˴ϴ�");
            }

        }
    }



    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("���� ���⿡ �����߽��ϴ�.");
                break;
            case ShowResult.Skipped:
                Debug.Log("���� ��ŵ�߽��ϴ�.");
                break;
            case ShowResult.Finished:
                // ���� ���� ���� ��� 
                /*gameManager.I.retry();*/
                break;
        }
    }
}