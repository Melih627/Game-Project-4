using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AltMenuManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject altMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (altMenuPanel != null)
        {
            altMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f);
            altMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.OutBack);
        }
       
    }

    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        PlayerPrefs.SetString("hangiOyun", hangiOyun);
        SceneManager.LoadScene("GameLevel");
    }

    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuLevel");
    }
}
