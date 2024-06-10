using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CL",menuName = "STO/CauDoDieuTraTriTue")]
public class CauDoDieuTraTriTue : ScriptableObject
{
    public string tenManEn,tenManVi;
    public Sprite img;
    public ThanhPhan objCauHoi;
    public L1Loai loai;
    public List<Motal1> motas;
}
[System.Serializable]
public class Motal1
{
    public List<string> yeuCau;
    public List<string> lyGiai;
}
public enum L1Loai
{
    TimTheoYeuCau,
    TimTatCa
}
