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

    private void Awake()
    {
        if(instance != null && instance != this)
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
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    //Show the loaded content in the Ad Unit:
    //Be sure to load the ad first with LoadAd method
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + adUnitId);
        Advertisement.Show(adUnitId);
    }

    //Implement Load Listener and Show Listener interface methods:
    public void OnUnityAdsAdLoaded(string adUnitId){}

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    //IUnityAdsShowListener methods not working correctly
    /*public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        UnPauseGame();
    }

    public void OnUnityAdsShowStart(string adUnitId){}
    
    public void OnUnityAdsShowClick(string adUnitId){}

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Show Completed");
        UnPauseGame();
    }*/

    public void OnUnityAdsReady(string adUnitId){}

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad Error: " + message);
        UnPauseGame();
    }

    public void OnUnityAdsDidStart(string adUnitId){}

    public void OnUnityAdsDidFinish(string adUnitId, ShowResult showResult)
    {
        Debug.Log("Ads finished");
        UnPauseGame();
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    private void UnPauseGame()
    {
        GameMaster.instance.UnPauseGame();
    }
}
