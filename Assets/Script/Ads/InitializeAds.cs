using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAds : MonoBehaviour
{
    private static InitializeAds instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //InitializeMobileAds();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeMobileAds()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            
        });
    }
    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });
    }
}
