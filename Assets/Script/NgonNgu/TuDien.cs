using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuDien : MonoBehaviour
{
    public List<DSTD> danhSach;
}
[System.Serializable]
public class DSTD
{
    public string key;
    [Header("Translate: 0 = En; 1 = Vi")]
    public List<string> txt = new List<string> {"", ""};
}
