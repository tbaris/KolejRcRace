using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesafeOlcerOn : MonoBehaviour {


    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        

        RaycastHit hit;
        if (Physics.Raycast(transform.position , -Vector3.up , out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue);
            AracKontrol script = GetComponentInParent<AracKontrol>();
            script.arkaMesafe = hit.distance;
        
           
        }



    }
}
