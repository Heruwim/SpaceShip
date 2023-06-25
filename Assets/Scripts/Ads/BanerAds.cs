using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BanerAds : MonoBehaviour
{
    [SerializeField] private BannerPosition _bannerPosition;
    [SerializeField] private string _androidAdUnitId = "Banner_Android";
    [SerializeField] private string _iOSAdUnitId = "Banner_iOS";

    private string _adUnitId;

    private void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
    }  

    private void Start()
    {
        Advertisement.Banner.SetPosition(_bannerPosition);
        StartCoroutine(LoadAdBanner());
    }

    private IEnumerator LoadAdBanner()
    {
        yield return new WaitForSeconds(1f);
        LoadBaner();
    }

    public void LoadBaner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBanerLoaded,
            errorCallback = OnBanerError
        };

        Advertisement.Banner.Load(_adUnitId, options);
    }

    private void OnBanerLoaded()
    {
        Debug.Log("Banner Loaded");
        ShowBanerAdd();
    }

    private void OnBanerError(string mesage)
    {
        Debug.Log($"Baner errror: {mesage}");
    }

    public void ShowBanerAdd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
    }

    private void OnBannerClicked() { }
    private void OnBannerShown() { }
    private void OnBannerHidden() { }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

}
