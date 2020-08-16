using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPanel;
    int kalanSure ;
    bool SuresaysinMi;

    [SerializeField]
    private GameObject sonucObj, zamanObj, dogruyanlisObj, playerObj, puanObj;
    // Start is called before the first frame update
    void Start()
    {
        kalanSure = 90;
        SuresaysinMi = true;
        sonucPanel.SetActive(false);

        sonucObj.SetActive(true);
        zamanObj.SetActive(true);
        dogruyanlisObj.SetActive(true);
        playerObj.SetActive(true);
        puanObj.SetActive(true);

        StartCoroutine(SureTimerRoutine());
    }
    IEnumerator SureTimerRoutine()
    {
        while (SuresaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
                
            }
            if (kalanSure <= 0)
            {
                SuresaysinMi = false;
                sureText.text = "";
                ekranıTemizle();
                sonucPanel.SetActive(true);
            }
            kalanSure--;
        }
    }

    void ekranıTemizle()
    {
        sonucObj.SetActive(false);
        zamanObj.SetActive(false);
        dogruyanlisObj.SetActive(false);
        playerObj.SetActive(false);
        puanObj.SetActive(false);


    }


}
