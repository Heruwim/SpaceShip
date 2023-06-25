using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMod;
    [SerializeField] private string _androidGameId = "5323687";
    [SerializeField] private string _iOsGameId = "5323686";

    private string _gameId;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsGameId 
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMod, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialization Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("InitializationFailed");

    }
}
