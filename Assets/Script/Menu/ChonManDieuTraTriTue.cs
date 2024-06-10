using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChonManDieuTraTriTue : MonoBehaviour
{
    [SerializeField] Image imgMan;
    [SerializeField] Text tenMan;
    private int iman;
    [SerializeField] GameObject KhoaMan;
    public void chonman()
    {
        PlayerPrefs.SetInt("ManHienTaiDieuTraTriTue", iman);
        SceneManager.LoadScene("DieuTraTriTue");
    }
    public void DatThongTin(int iman, Sprite img, string ten, bool b)
    {
        this.iman = iman;
        this.imgMan.sprite = img;
        this.tenMan.text = ten;
        KhoaMan.SetActive(!b);
    }
    public void DatLaiTen(string ten)
    {
        this.tenMan.text = ten;
    }
}
