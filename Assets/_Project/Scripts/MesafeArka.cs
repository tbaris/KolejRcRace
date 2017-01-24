using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesafeArka : MonoBehaviour {

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
           // Debug.Log(hit.distance);
            AracKontrol script = GetComponentInParent<AracKontrol>();
            script.onMesafe = hit.distance;
        }



    }
}
