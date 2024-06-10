using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoManChoi : MonoBehaviour
{
    public DuLieuGame DuLieu;
    public ChonManDieuTraTriTue nutChonManDieuTraTriTue;
    [SerializeField] Transform danhSachNutChonManDieuTraTriTue;
    [SerializeField] Transform danhSachNutChonManToanHocVui;
    public List<CauDoDieuTraTriTue> DTTT;
    public List<CauDoToanHocVui> THV;
    [SerializeField] ChonManToanHocVui nutChonManToanHocVui;
    private string ten;
    private void Start()
    {
        TaoManChoiToanHocVui();
        TaoManChoiDieuTraTriTue();
    }
    public void TaoManChoiToanHocVui()
    {
        for(int i = 0; i < THV.Count; i++)
        {
            ChonManToanHocVui nutmoi = Instantiate(nutChonManToanHocVui, danhSachNutChonManToanHocVui);
            nutmoi.DatTrangThaiCuaNut(i, MKNTHV(i));
        }
    }
    public void TaoManChoiDieuTraTriTue()
    {
        for(int i = 0; i < DTTT.Count; i++)
        {
            ChonManDieuTraTriTue nutmoi = Instantiate(nutChonManDieuTraTriTue, danhSachNutChonManDieuTraTriTue);
            if (PlayerPrefs.GetInt("ngonngu") == 0)
            {
                ten = DTTT[i].tenManEn;
            }
            else
            {
                ten = DTTT[i].tenManVi;
            }
            nutmoi.DatThongTin(i, DTTT[i].img, ten, MKNDTTT(i));
        }
    }
    public void DatLaiThongTin()
    {
        int man = 0;
        foreach (Transform tf in danhSachNutChonManDieuTraTriTue)
        {
            if (PlayerPrefs.GetInt("ngonngu") == 0)
            {
                ten = DTTT[man].tenManEn;
            }
            else
            {
                ten = DTTT[man].tenManVi;
            }
            tf.GetComponent<ChonManDieuTraTriTue>().DatLaiTen(ten);
            man++;
        }
    }
    private bool MKNTHV(int i)
    {
        return i <= DuLieu.tienDoCauDoToanHocVui;
    }
    private bool MKNDTTT(int i)
    {
        return i <= DuLieu.tienDoCauDoDieuTraTriTue;
    }
}
