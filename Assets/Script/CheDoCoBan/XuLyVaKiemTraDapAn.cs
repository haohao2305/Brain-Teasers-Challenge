using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XuLyVaKiemTraDapAn : MonoBehaviour
{
    public DuLieuGame duLieu;
    public VietDapAn dapAn;
    public GiaoDienCauHoi cauHoi;
    public GameObject viewPanel;
    public GameObject winPanel;
    public Text txtDapAn;
    public GameObject nextbt;
    public GiaoDienCauHoi gdch;
    public AudioClip dung,sai;

    private Color maubandau;
    private void Start()
    {
        maubandau = txtDapAn.color;
        if(PlayerPrefs.GetInt("ManHienTaiToanHocVui") >= gdch.cauHoiCoBans.Count - 1)
        {
            nextbt.SetActive(false);
        }
    }
    public void check()
    {
        if (dapAn.str == cauHoi.dapAn)
        {
            if (PlayerPrefs.GetInt("ManHienTaiToanHocVui") == duLieu.tienDoCauDoToanHocVui)
            {
                duLieu.TangTienDoToanHocVui();
            }
            StartCoroutine(DAD());
        }
        else
        {
            StartCoroutine(DAS());
        }
    }
    public void NextLevel()
    {
        int imdc = PlayerPrefs.GetInt("ManHienTaiToanHocVui") + 1;
        PlayerPrefs.SetInt("ManHienTaiToanHocVui", imdc);
    }
    IEnumerator DAS()
    {
        Singleton.Instance.PlaySaiSoundEffect();
        txtDapAn.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = maubandau;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = maubandau;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = maubandau;
    }
    IEnumerator DAD()
    {
        Singleton.Instance.PlayDungSoundEffect();
        viewPanel.SetActive(true);
        txtDapAn.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = maubandau;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = maubandau;
        yield return new WaitForSeconds(0.1f);
        txtDapAn.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        winPanel.SetActive(true);
        viewPanel.SetActive(false);
        txtDapAn.color = maubandau;
    }
}
