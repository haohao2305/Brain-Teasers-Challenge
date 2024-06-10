using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextR : MonoBehaviour
{
    public List<txtR> txt;
    void Start()
    {
        gameObject.GetComponent<Text>().text = txt[Random.Range(0, txt.Count)].eTxt[PlayerPrefs.GetInt("ngonngu")];
    }
}
[System.Serializable]
public class txtR
{
    public List<string> eTxt;
}
