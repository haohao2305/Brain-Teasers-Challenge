using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChonManToanHocVui : MonoBehaviour
{
    private int iman;
    [SerializeField] Text soMan;
    [SerializeField] GameObject KhoaMan;
    [SerializeField] Button nutAn;
    public void ChonMan()
    {
        PlayerPrefs.SetInt("ManHienTaiToanHocVui", iman);
        SceneManager.LoadScene("ToanHocVui");
    }
    public void DatTrangThaiCuaNut(int i,bool b)
    {
        this.iman = i;
        soMan.text = (iman+1).ToString();
        KhoaMan.SetActive(!b);
        nutAn.enabled = b;
    }
}
