using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsListener
{
    public static InterstitialAds instance;

    [SerializeField] private string androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string iOsAdUnitId = "Interstitial_iOS";
    private string adUnitId;
    private bool isAdLoaded = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Initialise();
            instance = this;
        }

    }

    private void Initialise()
    {
        //Get the Ad Unit ID for the current platform:
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOsAdUnitId : androidAdUnitId;
        Advertisement.AddListener(this);
    }

    //Load content to the Ad Unit:
    public void LoadAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    //Show the loaded content in the Ad Unit:
    //Be sure to load the ad first with LoadAd method
    public void ShowAd()
    {
        Advertisement.Show(adUnitId);
    }

    private IEnumerator ShowAdWhenLoaded()
    {
        yield return new WaitUntil(() => isAdLoaded);
        Advertisement.Show(adUnitId);
    }

    //Implement Load Listener and Show Listener interface methods:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsDidError(string message)
    {
        UnPauseGame();
    }

    public void OnUnityAdsDidFinish(string adUnitId, ShowResult showResult)
    {
        UnPauseGame();
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        isAdLoaded = true;
    }

    public void OnUnityAdsReady(string adUnitId) { }

    public void OnUnityAdsDidStart(string adUnitId) { }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    private void UnPauseGame()
    {
        GameMaster.instance.UnPauseGame();
    }
}
