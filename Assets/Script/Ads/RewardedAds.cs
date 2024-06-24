using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardedAds : MonoBehaviour
{
    [SerializeField] Button obt;
    private string _adUnitId = "";
    private RewardedAd _rewardedAd;
    private bool _isAdLoaded = false;
    [SerializeField] private XemDapAn xemDapAnTHV;
    [SerializeField] private ThietDat xemDapAnDTTT;
    [SerializeField] private RewardedAdsPlayModeType _playMode;

    public void LoadRewardedAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
        }

        Debug.Log("Loading the rewarded ad.");
        var adRequest = new AdRequest();
        RewardedAd.Load(_adUnitId, adRequest, OnAdLoaded);
    }

    private void OnAdLoaded(RewardedAd ad, LoadAdError error)
    {
        if (error != null || ad == null)
        {
            Debug.LogError("Rewarded ad failed to load: " + error);
            // Xử lý lỗi tải quảng cáo
            return;
        }

        _rewardedAd = ad;
        _isAdLoaded = true;
        obt.interactable = _isAdLoaded;
        Debug.Log("Rewarded ad loaded.");
    }

    public void ShowRewardedAd()
    {
        if (_isAdLoaded && _rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((reward) =>
            {
                Debug.Log("Rewarded ad rewarded the user.");
                HienThiHuongDan();
            });
            _isAdLoaded = false; // Xóa cờ sau khi hiển thị quảng cáo
            obt.interactable = _isAdLoaded;
        }
        else
        {
            Debug.Log("Rewarded ad is not loaded yet.");
            // Thông báo cho người dùng quảng cáo chưa sẵn sàng
        }
    }

    private void HienThiHuongDan()
    {
        switch (_playMode)
        {
            case RewardedAdsPlayModeType.ToanHocVui:
                xemDapAnTHV.XemQC();
                break;
            case RewardedAdsPlayModeType.DieuTraTriTue:
                xemDapAnDTTT.XemQC();
                break;
        }
    }
    public void LoadQC()
    {
        if (!_isAdLoaded)
        {
            LoadRewardedAd();
        }
    }
}
public enum RewardedAdsPlayModeType
{
    ToanHocVui,
    DieuTraTriTue
}
