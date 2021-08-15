using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    public static AdsInitializer instance;

    [SerializeField] private string androidGameId;
    [SerializeField] private string iOsGameId;
    [SerializeField] private bool testMode = true;
    [SerializeField] private bool enablePerPlacementMode = true;
    private string gameId;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            InitializeAds();
            instance = this;
        }
    }

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOsGameId : androidGameId;
        Advertisement.Initialize(gameId, testMode, enablePerPlacementMode, this);
    }

    public void OnInitializationComplete(){}

    public void OnInitializationFailed(UnityAdsInitializationError error, string message){}
}
