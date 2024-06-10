using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThietDatMenu : MonoBehaviour
{
    [SerializeField] private GameObject xM, M, xS, S;
    private void Start()
    {
        GetStringKeyAudio();
        Singleton.Instance.VolumeAudioSource();
        SetActiveBtn();
    }
    public void VDoiNgonNgu()
    {
        int x = PlayerPrefs.GetInt("ngonngu");
        if (x == 0)
        {
            PlayerPrefs.SetInt("ngonngu", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ngonngu", 0);
        }
    }
    private void SetActiveBtn()
    {
        xM.SetActive((PlayerPrefs.GetInt("music") == 1) ? false : true);
        M.SetActive((PlayerPrefs.GetInt("music") == 0) ? false : true);
        xS.SetActive((PlayerPrefs.GetInt("soundEffect") == 1) ? false : true);
        S.SetActive((PlayerPrefs.GetInt("soundEffect") == 0) ? false : true);
    }
    private void GetStringKeyAudio()
    {
        if (!PlayerPrefs.HasKey("music") && !PlayerPrefs.HasKey("soudEffect"))
        {
            PlayerPrefs.SetInt("music", 1);
            PlayerPrefs.SetInt("soundEffect", 1);
        }
    }
    public void SetEnaledMusic(int i)
    {
        PlayerPrefs.SetInt("music", i);
        Singleton.Instance.VolumeAudioSource();
        SetActiveBtn();
    }
    public void SetEnabledSoundEffect(int i)
    {
        PlayerPrefs.SetInt("soundEffect", i);
        Singleton.Instance.VolumeAudioSource();
        SetActiveBtn();
    }

}
