using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

[RequireComponent(typeof(AdsInitializer))]
public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string iOsAdUnitId = "Interstitial_iOS";
    private string adUnitId;

    private void Awake()
    {
        //Get the Ad Unit ID for the current platform:
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOsAdUnitId : androidAdUnitId;
    }

    //Load content to the Ad Unit:
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    //Show the loaded content in the Ad Unit:
    //Be sure to load the ad first with LoadAd method
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + adUnitId);
        Advertisement.Show(adUnitId, this);
    }

    //Implement Load Listener and Show Listener interface methods:
    public void OnUnityAdsAdLoaded(string adUnitId){}

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId){}
    
    public void OnUnityAdsShowClick(string adUnitId){}

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        GameMaster.instance.RestartLevel();
    }
}
