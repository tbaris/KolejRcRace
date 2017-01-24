using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleSence : MonoBehaviour {

    public int collectibleIden;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "pil")
        {
            if (collectibleIden == 0)
            {
                collectibleIden = 1;
            }
        }
    }
   


    // Update is called once per frame
    void Update () {
        Debug.Log(collectibleIden);


		
	}
}
