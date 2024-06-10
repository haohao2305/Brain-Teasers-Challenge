using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VietDapAn : MonoBehaviour
{
    public Text textDapAn;
    public string str="";
    public void Viet(int i)
    {
        if (str.Length < 11)
        {
            str += i;
            textDapAn.text = str;
        }
    }
    public void Xoa()
    {
        if (str.Length > 0)
        {
            str = str.Substring(0, str.Length - 1);
            if (str.Length == 0)
            {
                textDapAn.text = "_ _ _";
            }
            else
            {
                textDapAn.text = str;
            }
        }
    }
    public void XoaHet()
    {
        str = "";
        textDapAn.text = "_ _ _";
    }
}
