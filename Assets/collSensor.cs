using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collSensor : MonoBehaviour {

    public bool engel;

    private void OnCollisionEnter(Collision collision)
    {
        engel = true;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        engel = false;
    }
}
