using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carprazSagSen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            AracKontrol script = GetComponentInParent<AracKontrol>();
            script.carprazSagCarpMes = hit.distance;


        }
    }
}
