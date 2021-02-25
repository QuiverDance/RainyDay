using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADinit : MonoBehaviour
{
    static public ADinit instance;
    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    [System.Obsolete]
    void Start()
    {
        instance = this;

        //MobileAds.Initialize(initStatus => { });

        #if UNITY_ANDROID
        string appId = "ca-app-pub-4226825554593826~6585095270";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(appId);
        MobileAds.Initialize((initStatue) =>
        {
            RequestBanner();
            RequestInterstitial();
        });
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4226825554593826/9936682735";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-4226825554593826/2353706187";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.interstitialAd = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(request);
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void InterstitialAdShow()
    {
        int random = 0;
        if (this.interstitialAd.IsLoaded())
        {
            random = Random.Range(0, 5);
            if(random == 0)
                this.interstitialAd.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }
}
