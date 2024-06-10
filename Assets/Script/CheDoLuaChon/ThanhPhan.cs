using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanhPhan : MonoBehaviour
{
    public List<DiemCanChon> doituong;
    public GameObject img;
    public int loai;
    public ThietDat thietDat;
    private void Start()
    {
        int thutu = 0;
        if (((int)loai) == 0)
        {
            doituong[0].gameObject.SetActive(true);
            for(int i = 1; i < doituong.Count; i++)
            {
                doituong[i].gameObject.SetActive(false);
            }
        }
        else
        {
            foreach(DiemCanChon g in doituong)
            {
                g.gameObject.SetActive(true);
            }
        }
        foreach (DiemCanChon s in doituong)
        {
            s.thutu = thutu;
            s.thanhPhan = this;
            thutu++;
        }
    }
    public void SuLyKetQua(GameObject dv,int tt)
    {
        if(loai == 0 && (thietDat.tiendo+1)<doituong.Count)
        {
            doituong[tt+1].gameObject.SetActive(true);
        }
        dv.SetActive(false);
        thietDat.VHienThiBangLyGiai(tt);
    }
    public void DatThongTinThanhPhan(GameObject vp,GameObject cs, ThietDat td)
    {
        thietDat = td;
        img.GetComponent<ThaoTacAnhChinh>().DatThongTinDoiTuong(vp, cs);
        foreach (DiemCanChon s in doituong)
        {
            s.viewPanel = vp;
        }
    }
}
