using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrans : MonoBehaviour
{
    public string key;
    public string tp;
    public void txtreload(string VE)
    {
        GetComponent<Text>().text = VE + tp;
    }
    public void txtrekey(string newkey)
    {
        key = newkey;
    }
}
