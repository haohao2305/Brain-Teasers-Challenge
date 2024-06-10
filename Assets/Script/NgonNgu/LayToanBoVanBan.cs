using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayToanBoVanBan : MonoBehaviour
{
    public TuDien tuDien;
    private List<TextTrans> txtObjs = new List<TextTrans>();
    private int nn;
    void Start()
    {
        nn = PlayerPrefs.GetInt("ngonngu");
        DoiNgonNgu();
    }
    public void DoiNgonNgu()
    {
        nn = PlayerPrefs.GetInt("ngonngu");
        TextTrans[] txt = Resources.FindObjectsOfTypeAll<TextTrans>();
        txtObjs.AddRange(txt);
        foreach (TextTrans t in txtObjs)
        {
            foreach (DSTD td in tuDien.danhSach)
            {
                if (t.key == td.key)
                {
                    t.txtreload(td.txt[nn]);
                }
            }
        }
    }
    public void DoiMotThanhPhan(TextTrans textTrans)
    {
        foreach (DSTD td in tuDien.danhSach)
        {
            if (textTrans.key == td.key)
            {
                textTrans.txtreload(td.txt[nn]);
            }
        }
    }
}
