using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ThietDat : MonoBehaviour
{
    [SerializeField] DuLieuGame duLieu;
    [SerializeField] List<CauDoDieuTraTriTue> cauHoiLuaChonL1s;
    [SerializeField] Transform content;
    private List<string> yeuCau = new List<string>();
    private List<string> lyGiai = new List<string>();
    [SerializeField] Text txtyeucau;
    [SerializeField] GameObject viewPanel;
    [SerializeField] GameObject chonSai;
    [SerializeField] GameObject lyGiaiPanel;
    [SerializeField] Text txtLyGiai;
    public int tiendo;
    private int icount;
    [SerializeField] GameObject HoanThanhPanel;
    [SerializeField] GameObject NextLevelBt;
    [SerializeField] TextTrans txtlevel;
    private ThanhPhan thanhphan;
    private void Awake()
    {
        txtlevel.tp = (PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue") + 1).ToString();
    }
    private void Start()
    {
        DatThongTinMan();
        setText1();
    }
    private void DatThongTinMan()
    {
        int x = PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue");
        var g = Instantiate(cauHoiLuaChonL1s[x].objCauHoi, content);
        thanhphan = g;
        g.loai = (int)cauHoiLuaChonL1s[x].loai;
        g.DatThongTinThanhPhan(viewPanel, chonSai, this);
        icount = g.doituong.Count;
        foreach (Motal1 m in cauHoiLuaChonL1s[x].motas)
        {
            yeuCau.Add(m.yeuCau[PlayerPrefs.GetInt("ngonngu")]);
            lyGiai.Add(m.lyGiai[PlayerPrefs.GetInt("ngonngu")]);
        }
        if (x >= cauHoiLuaChonL1s.Count - 1)
        {
            NextLevelBt.SetActive(false);
        }
    }
    private void setText1()
    {
        StartCoroutine(TypeText());
    }
    private void setText2()
    {
        txtyeucau.text = yeuCau[0] + "(" + (tiendo) + "/" + (icount) + ")";
    }
    private void reText()
    {
        txtyeucau.text = "";
        txtLyGiai.text = "";
    }
    public void TienDoTiepTheo()
    {
        if (tiendo+1 < yeuCau.Count && (int)cauHoiLuaChonL1s[PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue")].loai == 0)
        {
            tiendo++;
            setText1();
        }
        else if(tiendo + 1 < yeuCau.Count && (int)cauHoiLuaChonL1s[PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue")].loai == 1)
        {
            tiendo++;
            setText2();
        }
        else
        {
            reText();
            StartCoroutine(ThongBaoHoanThanh());
        }
    }
    public void VHienThiBangLyGiai(int tt)
    {
        Singleton.Instance.PlayDungSoundEffect();
        txtLyGiai.text = lyGiai[tt];
        lyGiaiPanel.SetActive(true);
    }
    public void XemQC()
    {
        foreach(DiemCanChon x in thanhphan.doituong)
        {
            if (x.gameObject.activeSelf)
            {
                x.HienThiGoiY();
                return;
            }
        }
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("ManHienTaiDieuTraTriTue", ((PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue"))+1));
    }
    // hieu ung van ban
    IEnumerator TypeText()
    {
        viewPanel.SetActive(true);
        txtyeucau.gameObject.GetComponent<ContentSizeFitter>().enabled = false;
        txtyeucau.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(txtyeucau.gameObject.GetComponent<RectTransform>().sizeDelta.x, 450);
        StringBuilder currentText = new StringBuilder();
        for (int i = 0; i < yeuCau[tiendo].Length; i++)
        {
            currentText.Append(yeuCau[tiendo][i]);
            txtyeucau.text = currentText.ToString();
            yield return new WaitForSeconds(0.03f);
        }
        txtyeucau.gameObject.GetComponent<ContentSizeFitter>().enabled = true;
        viewPanel.SetActive(false);
        if ((int)cauHoiLuaChonL1s[PlayerPrefs.GetInt("ManHienTaiDieuTraTriTue")].loai == 1)
        {
            txtyeucau.text += "(" + (tiendo) + "/" + (icount) + ")";
        }
    }
    IEnumerator ThongBaoHoanThanh()
    {
        viewPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        HoanThanhPanel.SetActive(true);
        viewPanel.SetActive(false);
        duLieu.TangTienDoDieuTraTriTue();
    }
}
