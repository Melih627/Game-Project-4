using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    float angle;
    float donusHizi=5f;

    [SerializeField]
    private Transform mermiYeri;
    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topSesi;

    float sonrakiAtis;

    float BulletRecoilTime=500f;

    public bool rotaDegissinMi;

    private void Start()
    {
        rotaDegissinMi = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotaDegissinMi)
        {
            RotateDegistir();
        }
        
    }

    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (angle>-70 && angle<70)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }
        
       


        
        if (Input.GetMouseButtonDown(0))
        {
            

            if (Time.time > sonrakiAtis)
            {
                sonrakiAtis = Time.time + BulletRecoilTime / 1000;
                MermiAt();
            }
            
            
        }
        
        
    }
    void MermiAt()
    {

        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            audioSource.PlayOneShot(topSesi);
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,5)],mermiYeri.position,mermiYeri.rotation ) as GameObject;
    }

}
