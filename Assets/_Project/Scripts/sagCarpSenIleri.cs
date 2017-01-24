using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagCarpSenIleri : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            AracKontrol asd = GetComponentInParent<AracKontrol>();
            asd.sagCarpMes = hit.distance;
        }


    }
}
