using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girisAnimasyonu : MonoBehaviour {

    public Camera secimCam;
    public Transform sonDurum;
    public GameObject aniCam;

	// Use this for initialization
	void Start () {
        
       // Destroy(aniCam);
    }
	
	// Update is called once per frame
	void Update () {
       
            
        
        
    }
    public void stopAnim()
    {
        
        GetComponent<Animator>().Stop();
    }
  
}
