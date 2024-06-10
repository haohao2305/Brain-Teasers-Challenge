using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillA : MonoBehaviour
{
    public bool chonDung;
    public bool tatObj;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        setamount();
    }
    private void OnEnable()
    {
        if (image)
        {
            setamount();
        }
    }
    private void FixedUpdate()
    {
        if (chonDung)
        {
            if (image.fillAmount == 1&&tatObj)
            {
                gameObject.SetActive(false);
            }
            image.fillAmount += (Time.fixedDeltaTime*1.5f);
        }
        else
        {
            if (image.fillAmount == 0&&tatObj)
            {
                gameObject.SetActive(false);
            }
            image.fillAmount -= (Time.fixedDeltaTime*0.5f);
        }
    }
    void setamount()
    {
        if (chonDung)
        {
            image.fillAmount = 0;
        }
        else
        {
            image.fillAmount = 1;
        }
    }
}
