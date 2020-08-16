using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool sesPanelAcikMi;
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;
    [SerializeField]
    private GameObject sesPanel;
    // Start is called before the first frame update
    void Start()
    {
        sesPanelAcikMi = false;
        sesPanel.GetComponent<RectTransform>().localPosition = new Vector3(0, -69.8f, 0);
        menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void ikinciSahneGec()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        SceneManager.LoadScene("ikinciMenuLevel");
    } 
    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        
        if (!sesPanelAcikMi)
        {
            sesPanel.GetComponent<RectTransform>().DOLocalMoveX(160, 0.5f);
            sesPanelAcikMi = true;
        }
        else
        {
            sesPanel.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
            sesPanelAcikMi = false;
        }
    }
    public void oyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        Application.Quit();
    }
    
}
