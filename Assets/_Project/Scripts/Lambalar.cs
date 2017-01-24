using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lambalar : MonoBehaviour
{

    public GameObject stoplar;
    public GameObject farlar;



    void Update()
    {
        AracKontrol gazAl = this.gameObject.GetComponent<AracKontrol>();
        float gaz = gazAl.gaz;
        if (gaz < 0)
        {
            stoplar.SetActive(true);

        }
        if (gaz > 0)
        { 
            stoplar.SetActive(false);

        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(farlar.activeSelf)
            {
                farlar.SetActive(false);

            }
            else
                farlar.SetActive(true);

        }
    }
}