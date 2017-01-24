using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarisBasla : MonoBehaviour
{
    public int basladimi = 0;
    public GameObject ui;
    private Canvas canvas;
    public GameObject aniCam;
    public GameObject baslat1isik;
    public GameObject baslat2isik;
    public GameObject baslat3isik;
    public GameObject baslat4isik;
    public GameObject baslat5isik;
    public GameObject baslatYesil;
    public float start1;
    public int ready = 0;
    public AudioClip startSes1;
    public AudioClip startSes2;
    public bool basla1 = false;
    public bool basla2 = false;
    public bool basla3 = false;
    public bool basla4 = false;
    public bool basla5 = false;
    public bool baslaY = false;

    public void baslat()
    {
 
        aniCam.SetActive(false);
        start1 = Time.time;
     //   Debug.Log(start1);
        ready = 1;
    }
   void Update()
    {
       
        if (ready == 1)
        {
            if(start1 == 0)
            {

                start1 = Time.time;

            }
        if (start1 + 1f <= Time.time)
        {
                
                if (!basla1)
                {
                    transform.GetComponent<AudioSource>().PlayOneShot(startSes1, 1F);
                    basla1 = true;
                }
                
                baslat1isik.gameObject.SetActive(true);
                
                if (start1 + 2f <= Time.time)
            {
                baslat2isik.gameObject.SetActive(true);
                    if (!basla2)
                    {
                        transform.GetComponent<AudioSource>().PlayOneShot(startSes1, 1F);
                        basla2 = true;
                    }
                    if (start1 + 3f <= Time.time)
                {
                    baslat3isik.gameObject.SetActive(true);
                        if (!basla3)
                        {
                            transform.GetComponent<AudioSource>().PlayOneShot(startSes1, 1F);
                            basla3 = true;
                        }
                        if (start1 + 4f <= Time.time)
                    {
                        baslat4isik.gameObject.SetActive(true);
                            if (!basla4)
                            {
                                transform.GetComponent<AudioSource>().PlayOneShot(startSes1, 1F);
                                basla4 = true;
                            }
                            if (start1 + 5f <= Time.time)
                        {
                            baslat5isik.gameObject.SetActive(true);
                                if (!basla5)
                                {
                                    transform.GetComponent<AudioSource>().PlayOneShot(startSes1, 1F);
                                    basla5 = true;
                                }
                                if (start1 + 6f <= Time.time)
                            {
                                baslat1isik.gameObject.SetActive(false);
                                baslat2isik.gameObject.SetActive(false);
                                baslat3isik.gameObject.SetActive(false);
                                baslat4isik.gameObject.SetActive(false);
                                baslat5isik.gameObject.SetActive(false);
                                baslatYesil.gameObject.SetActive(true);
                                    if (!baslaY)
                                    {
                                        transform.GetComponent<AudioSource>().PlayOneShot(startSes2, 1F);
                                        baslaY = true;
                                    }
                                    basladimi = 1;
                                if (start1 + 10f <= Time.time)
                                {

                                    baslatYesil.gameObject.SetActive(false);
                                    start1 = 0;
                                    ready = 0;

}

                            }

                        }

                    }

                }


            }

        }
    }
    
        }

}

