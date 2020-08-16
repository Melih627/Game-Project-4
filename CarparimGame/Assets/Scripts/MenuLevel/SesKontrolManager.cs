using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrolManager : MonoBehaviour
{
    private void Start()
    {
        sesiAc();
    }
    public void sesiAc()
    {
        PlayerPrefs.SetInt("sesDurum", 1);

    }
    public void sesiKapat()
    {
        PlayerPrefs.SetInt("sesDurum", 0);

    }


}
