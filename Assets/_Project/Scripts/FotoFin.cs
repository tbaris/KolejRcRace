using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotoFin : MonoBehaviour {

    public GameObject PickUp;
    public GameObject Futuristic;
    public GameObject Sport;
    public GameObject Sedan;
    public GameObject Muscle;
    public GameObject Suv;

    public int siraPickUp;
    public int siraFuturistic;
    public int siraSport;
    public int siraSedan;
    public int siraMuscle;
    public int siraSuv;
    public int sira = 0;
    public int hedefTur = 1;
    bool PickUpEx = true;
    bool FuturisticEx = true;
    bool SportEx = true;
    bool SedanEx = true;
    bool MuscleEx = true;
    bool SuvEx = true;
    public Text turGoster;



    private void Awake()
    {
        hedefTur = 1;
    }
    // Update is called once per frame
    public void turArttir()
    {

        if (hedefTur >= 10)
        {
            hedefTur = 10;
        }
        else
        {
            hedefTur++;
        }
        
    }
    public void turAzalt()
    {
        if (hedefTur <= 1)
        {
            hedefTur = 1;
        }
        else
        {
            hedefTur--;
        }

    }
    void Update()
    {
        turGoster.text = "Laps : "+hedefTur;
    

        AracKontrol PickUpScript = PickUp.GetComponent<AracKontrol>();
        AracKontrol FuturisticScript = Futuristic.GetComponent<AracKontrol>();
        AracKontrol SportScript = Sport.GetComponent<AracKontrol>();
        AracKontrol SedanScript = Sedan.GetComponent<AracKontrol>();
        AracKontrol MuscleScript = Muscle.GetComponent<AracKontrol>();
        AracKontrol SuvScript = Suv.GetComponent<AracKontrol>();
       
        

        if (PickUpScript.bitti && PickUpEx)
        {
            sira++;
            siraPickUp = sira;
            PickUpEx = false;
            PickUpScript.bitisSira = siraPickUp;
        }
        if (FuturisticScript.bitti && FuturisticEx)
        {
            sira++;
            siraFuturistic = sira;
            FuturisticEx = false;
           // Debug.Log("FuturisticEx");
        }
        if (SportScript.bitti && SportEx)
        {
            sira++;
            siraSport = sira;
            SportEx = false;
            //Debug.Log("SportEx");
        }
        if (SedanScript.bitti && SedanEx)
        {
            sira++;
            siraSedan = sira;
            SedanEx = false;
          //  Debug.Log("SedanEx");
        }
        if (MuscleScript.bitti && MuscleEx)
        {
            sira++;
            siraMuscle = sira;
            MuscleEx = false;
           // Debug.Log("MuscleEx");
        }
        if (SuvScript.bitti && SuvEx)
        {
            sira++;
            siraSuv = sira;
            SuvEx = false;
           // Debug.Log("SuvEx");
        }
        PickUpScript.bitisSira = siraPickUp;
        SuvScript.bitisSira = siraSuv;
        MuscleScript.bitisSira = siraMuscle;
        SedanScript.bitisSira = siraSedan;
        SportScript.bitisSira = siraSport;
        FuturisticScript.bitisSira = siraFuturistic;

    }
}
