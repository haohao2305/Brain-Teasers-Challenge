using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XemDapAn : MonoBehaviour
{
    private bool xcq;
    public GameObject ObjAds, ObjDapAn;
    private void OnEnable()
    {
        if (xcq)
        {
            ObjAds.SetActive(false);
            ObjDapAn.SetActive(true);
        }
        else
        {
            ObjDapAn.SetActive(false);
            ObjAds.SetActive(true);
        }
    }
    public void XemQC()
    {
        xcq = true;
        ObjAds.SetActive(false);
        ObjDapAn.SetActive(true);
    }
}
