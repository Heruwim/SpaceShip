using UnityEngine;
using UnityEngine.Advertisements;

public class InsterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InsterstitialAds S;

    [SerializeField] private string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string _iOSAdUnitId = "Interstitial_iOS";

    private string _adUniitID;

    private void Awake()
    {
        S = this;

        _adUniitID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUniitID);
        Advertisement.Load(_adUniitID, this);
    }
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + _adUniitID);
        Advertisement.Show(_adUniitID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUniitID} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUniitID} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }
}
