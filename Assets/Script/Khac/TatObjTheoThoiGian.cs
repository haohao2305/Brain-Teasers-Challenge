using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatObjTheoThoiGian : MonoBehaviour
{
    public float time;
    private void OnEnable()
    {
        Invoke("tat", time);
    }
    private void tat()
    {
        gameObject.SetActive(false);
    }
}
