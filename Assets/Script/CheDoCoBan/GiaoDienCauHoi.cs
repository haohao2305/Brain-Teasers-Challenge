using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienCauHoi : MonoBehaviour
{
    public List<CauDoToanHocVui> cauHoiCoBans;
    [SerializeField] Image imgCauHoi;
    [SerializeField] Image imgDapAn;
    [SerializeField] Text txtCauHoi;
    [SerializeField] Text txtDapAn;
    [SerializeField] GameObject DapAnPanel;
    public string dapAn;
    [SerializeField] Text txtHTDA;
    //
    public TextTrans txtman;
    public LayToanBoVanBan vanban;
    void Start()
    {
        DatThongTinMan();
    }
    private void DatThongTinMan()
    {
        int x = PlayerPrefs.GetInt("ManHienTaiToanHocVui");
        imgCauHoi.sprite = cauHoiCoBans[x].imgCauHoi;
        imgDapAn.sprite = cauHoiCoBans[x].imgDapAn;
        dapAn = cauHoiCoBans[x].dapAn;
        
        txtCauHoi.text = "" + cauHoiCoBans[x].txtCauHoi[PlayerPrefs.GetInt("ngonngu")];
        if (cauHoiCoBans[x].hienThiDapAn)
        {
            txtHTDA.text = dapAn;
        }
        if (cauHoiCoBans[x].hienThiVanBanGiaiThich)
        {
            txtDapAn.text = "" + cauHoiCoBans[x].txtGiaiThich[PlayerPrefs.GetInt("ngonngu")];
            DapAnPanel.SetActive(true);
        }

        txtman.tp = (x + 1).ToString();
        vanban.DoiMotThanhPhan(txtman);
    }
}
