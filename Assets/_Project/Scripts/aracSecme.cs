using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aracSecme : MonoBehaviour {

    public delegate void yarisBasla();
    public static event yarisBasla Basla;
    public GameObject aracSec;


    public void yarisBaslat()
    {
        AracKontrol script = aracSec.GetComponent<AracKontrol>();
        script.akliVarmi = false;
        Basla();
    }
}
