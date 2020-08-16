using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    PlayerManager playerManager;
    string hangiOyun;
    int birinciCarpan;
    int ikinciCarpan;
    int dogruSonuc,birinciYanlis,ikinciYanlis;
    public int dogruAdet, yanlisAdet,Puan;

    [SerializeField]
    private Text dogruTxt, yanlisTxt, puanTxt;

    [SerializeField]
    private Text soruText,birinciTxt,ikinciTxt,ucuncuTxt;
    AdMobManager adMobManager;
    private void Awake()
    {
        adMobManager = Object.FindObjectOfType<AdMobManager>();
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        Puan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        dogruTxt.text = dogruAdet.ToString()+" DOĞRU";
        yanlisTxt.text = yanlisAdet.ToString()+" YANLIŞ";
        puanTxt.text = Puan.ToString()+ " PUAN";
        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
            
        }
        StartCoroutine(baslaYaziRoutine());
       
    }
    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);
        OyunaBasla();
    }
    public void OyunaBasla()
    {
        playerManager.rotaDegissinMi=true;
        soruyuYazdir();

        adMobManager.ShowBanner();

    }

    void BirinciCarpanAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;
            case "uc":
                birinciCarpan = 3;
                break;
            case "dort":
                birinciCarpan = 4;
                break;
            case "bes":
                birinciCarpan = 5;
                break;
            case "alti":
                birinciCarpan = 6;
                break;
            case "yedi":
                birinciCarpan = 7;
                break;
            case "sekiz":
                birinciCarpan = 8;
                break;
            case "dokuz":
                birinciCarpan = 9;
                break;
            case "onS":
                birinciCarpan = 10;
                break;
            case "karisik":
                birinciCarpan = Random.Range(2,11);
                break;

        }

        
    }
    void soruyuYazdir()
    {
        BirinciCarpanAyarla();
        ikinciCarpan = Random.Range(2, 11);
        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();

        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        sonuclariYazdir();

    }

    void sonuclariYazdir()
    {
        birinciYanlis = dogruSonuc + Random.Range(2, 10);
        if (dogruSonuc>10)
        {
            ikinciYanlis = dogruSonuc - Random.Range(2, 8);
        }else
        {
            ikinciYanlis = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }

        int rastgeleDeger = Random.Range(1, 100);
        if (rastgeleDeger <= 33)
        {
            birinciTxt.text = dogruSonuc.ToString();
            ikinciTxt.text = birinciYanlis.ToString();
            ucuncuTxt.text = ikinciYanlis.ToString();
        }else if(rastgeleDeger>33 && rastgeleDeger <= 66)
        {
            ikinciTxt.text = dogruSonuc.ToString();
            birinciTxt.text = birinciYanlis.ToString();
            ucuncuTxt.text = ikinciYanlis.ToString();
        }
        else
        {
            ucuncuTxt.text = dogruSonuc.ToString();
            birinciTxt.text = birinciYanlis.ToString();
            ikinciTxt.text = ikinciYanlis.ToString();
        }

        

    }
    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            Puan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, 0.1f);
        }else
        {
           yanlisAdet++;;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, 0.1f);

        }
        dogruTxt.text = dogruAdet.ToString() + " DOĞRU";
        yanlisTxt.text = yanlisAdet.ToString() + " YANLIŞ";
        puanTxt.text = Puan.ToString() + " PUAN";


        soruyuYazdir();
    }
    public void tekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void AnaMenuDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    
}
