using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiemCanChon : MonoBehaviour, IPointerClickHandler
{
    public int thutu;
    public GameObject ChonDung;
    public GameObject GoiY;
    public GameObject viewPanel;
    public ThanhPhan thanhPhan;
    public void OnPointerClick(PointerEventData eventData)
    {
        ChonDung.SetActive(true);
        viewPanel.SetActive(true);
        StartCoroutine(demNguoc());
    }
    public void HienThiGoiY()
    {
        GoiY.SetActive(true);
    }
    IEnumerator demNguoc()
    {
        yield return new WaitForSeconds(0.6f);
        GoiY.SetActive(false);
        viewPanel.SetActive(false);
        thanhPhan.SuLyKetQua(gameObject,thutu);
        gameObject.SetActive(false);
    }
}
