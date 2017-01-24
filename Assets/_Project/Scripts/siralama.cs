using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class siralama : MonoBehaviour
    {
        //public AracKontrol AracKontrol;
        public GameObject suv;
        public GameObject sedan;
        public GameObject sport;
        public GameObject muscle;
        public GameObject futuristic;
        public GameObject pickup;
        public int suvSira;
        public int sedanSira;
        public int sportSira;
        public int muscleSira;
        public int futuristicSira;
        public int pickupSira;
        public TextMesh suvSiraUi;
        public TextMesh sedanSiraUi;
        public TextMesh sportSiraUi;
        public TextMesh muscleSiraUi;
        public TextMesh futuristicSiraUi;
        public TextMesh pickupSiraUi;


        /*int muscleScore = 300;
        int suvscore = 500;
        int sedanScore = 261;
        int pickupScore = 31;
        int futuristicScore = 26;
        int sportScore = 854;*/

        void Update()
        {
            AracKontrol musclecar = muscle.GetComponent<AracKontrol>();
            AracKontrol suvcar = suv.GetComponent<AracKontrol>();
            AracKontrol pickupcar = pickup.GetComponent<AracKontrol>();
            AracKontrol sedancar = sedan.GetComponent<AracKontrol>();
            AracKontrol futuristiccar = futuristic.GetComponent<AracKontrol>();
            AracKontrol sportcar = sport.GetComponent<AracKontrol>();
            int muscleScore = musclecar.neKadarOnde;
            int suvscore = suvcar.neKadarOnde;
            int sedanScore = sedancar.neKadarOnde;
            int pickupScore = pickupcar.neKadarOnde;
            int futuristicScore = futuristiccar.neKadarOnde;
            int sportScore = sportcar.neKadarOnde;

            ArrayList sList = new ArrayList();
            sList.Add(muscleScore);
            sList.Add(suvscore);
            sList.Add(sedanScore);
            sList.Add(pickupScore);
            sList.Add(futuristicScore);
            sList.Add(sportScore);

            sList.Sort();
            sList.Reverse();

            muscleSira = sList.IndexOf(muscleScore)+ 1;
            suvSira = sList.IndexOf(suvscore)+1;
            sedanSira = sList.IndexOf(sedanScore)+1;
            pickupSira = sList.IndexOf(pickupScore)+1;
            futuristicSira = sList.IndexOf(futuristicScore)+1;
            sportSira = sList.IndexOf(sportScore)+1;

            muscleSiraUi.text =  muscleSira.ToString() + ".";
            suvSiraUi.text = suvSira.ToString() + ".";
            sedanSiraUi.text = sedanSira.ToString() + ".";
            pickupSiraUi.text = pickupSira.ToString() + ".";
            futuristicSiraUi.text = futuristicSira.ToString() + ".";
            sportSiraUi.text = sportSira.ToString() + ".";

            //Isin bitince kaldır
          //  Debug.Log(muscleSira);
          //  Debug.Log(muscleScore);
           // Debug.Log(suvSira);
          //  Debug.Log(sedanSira);
          //  Debug.Log(pickupSira);
          //  Debug.Log(futuristicSira);
          //  Debug.Log(sportSira);
            //Isin bitince kaldır
            

            sList.Clear();
        }

    }
}
