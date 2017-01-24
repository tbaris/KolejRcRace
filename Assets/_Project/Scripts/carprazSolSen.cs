using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carprazSolSen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            AracKontrol script = GetComponentInParent<AracKontrol>();
            script.carprazSolCarpMes = hit.distance;


        }
    }
}
