using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solCarpSenIleri : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
      /* float angle = Mathf.LerpAngle(0, 5, Time.deltaTime * 1000);
       transform.eulerAngles = new Vector3(0,angle, 0);
        if(angle == 5)
        {
            angle = 0;
        }*/
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            AracKontrol script = GetComponentInParent<AracKontrol>();
            script.solCarpMes = hit.distance;


        }

    }
}
