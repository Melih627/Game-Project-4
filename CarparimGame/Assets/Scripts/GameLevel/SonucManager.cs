using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SonucManager : MonoBehaviour
{

    float sureTimer;
    bool resimAcilsinMi;

    [SerializeField]
    private Image sonucImage;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    GameManager gameManager;

    [SerializeField]
    private GameObject tekrarBtn, anaBtn;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {

        sureTimer = 0;
        resimAcilsinMi = true;
        dogruText.text = gameManager.dogruAdet.ToString()+"DOĞRU";
        yanlisText.text = gameManager.yanlisAdet.ToString()+"YANLIŞ" ;
        puanText.text = gameManager.Puan.ToString()+"PUAN";
        tekrarBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        anaBtn.GetComponent<RectTransform>().localScale = Vector3.zero;


        StartCoroutine(ResimRoutine());
    }


    IEnumerator ResimRoutine()
    {
        while (resimAcilsinMi)
        {
            sureTimer += .15f;
            sonucImage.fillAmount = sureTimer;
            yield return new WaitForSeconds(0.1f);
            if (sureTimer >= 1)
            {
                sureTimer = 1;
                tekrarBtn.GetComponent<RectTransform>().DOScale(1, .3f);
                anaBtn.GetComponent<RectTransform>().DOScale(1, .3f);

                resimAcilsinMi = false;
            }

        }

    }
}
