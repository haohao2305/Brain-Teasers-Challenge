using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Cau",menuName = "STO/CauDoToanHocVui")]
public class CauDoToanHocVui : ScriptableObject
{
    public Sprite imgCauHoi;
    public Sprite imgDapAn;
    public bool hienThiDapAn;
    public string dapAn;
    public List<string> txtCauHoi = new List<string> {"","" };
    public bool hienThiVanBanGiaiThich;
    public List<string> txtGiaiThich = new List<string> {"","" };
}
