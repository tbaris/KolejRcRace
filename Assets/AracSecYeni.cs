using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AracSecYeni : MonoBehaviour {

    public GameObject suv;
    public GameObject sedan;
    public GameObject sport;
    public GameObject muscle;
    public GameObject futuristic;
    public GameObject pickup;
    public int bakilanArac = 0;
    public GameObject secimKamera;
    public GameObject MainCamera;
    public GameObject Basla;
    
    


    // Use this for initialization
    void Start () {
        
		
	}
     public void sagDon()
    {
        if (bakilanArac == 300)
        { bakilanArac = 0; }
        else
        {
            bakilanArac += 60;
        }
    }

    public void solDon()
    {
        if (bakilanArac == 0)
        { bakilanArac = 300; }
        else
        {
            bakilanArac -= 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Return))
        {
            aracSecildi();
        }*/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (bakilanArac == 0)
            { bakilanArac = 300; }
            else
            {
                bakilanArac -= 60;
            }
          
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (bakilanArac == 300)
            { bakilanArac = 0; }
            else
            {
                bakilanArac += 60;
            }
       
        }
        float donus = Mathf.LerpAngle(secimKamera.transform.eulerAngles.y, bakilanArac, Time.deltaTime );
        secimKamera.transform.eulerAngles = new Vector3(0, donus, 0);
    }
    public void aracSecildi()
    {
        if(bakilanArac== 0)
        {
            AracKontrol musclecar = muscle.GetComponent<AracKontrol>();
            musclecar.oyuncuAta();
        }
        if (bakilanArac == 60)
        {
            AracKontrol suvcar = suv.GetComponent<AracKontrol>();
            suvcar.oyuncuAta();
        }
        if (bakilanArac == 120)
        {
            AracKontrol pickupcar = pickup.GetComponent<AracKontrol>();
            pickupcar.oyuncuAta();
        }
        if (bakilanArac == 180)
        {
            AracKontrol sedancar = sedan.GetComponent<AracKontrol>();
            sedancar.oyuncuAta();
        }
        if (bakilanArac == 240)
        {
            AracKontrol futuristiccar = futuristic.GetComponent<AracKontrol>();
            futuristiccar.oyuncuAta();
        }
        if (bakilanArac == 300)
        {
            AracKontrol sportcar = sport.GetComponent<AracKontrol>();
            sportcar.oyuncuAta();
        }
     


    }
	
}
