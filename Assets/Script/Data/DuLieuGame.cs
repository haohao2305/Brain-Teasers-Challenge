using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuLieuGame : MonoBehaviour
{
    //public DuLieuMoi duLieuMoi;
    public int tienDoCauDoToanHocVui;
    public int tienDoCauDoDieuTraTriTue;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("alldata"))
        {
            LoadData();
        }
        else
        {
            SaveData();
        }
    }
    public void TangTienDoToanHocVui()
    {
        tienDoCauDoToanHocVui++;
        SaveData();
    }
    public void TangTienDoDieuTraTriTue()
    {
        tienDoCauDoDieuTraTriTue++;
        SaveData();
    }
    private void SaveData()
    {
        string data = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("alldata", data);
    }
    private void LoadData()
    {
        string data = PlayerPrefs.GetString("alldata");
        JsonUtility.FromJsonOverwrite(data, this);
    }
}