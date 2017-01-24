using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antenEsne : MonoBehaviour {
    public ConfigurableJoint AntenParca;
    public Rigidbody antenParcaRB;

    public Vector3 Vec1;
    private Quaternion QVec1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (antenParcaRB.IsSleeping())
        {
            antenParcaRB.WakeUp();
        }
        
           float ivmeX = this.gameObject.GetComponent<Rigidbody>().velocity.x;
            float ivmez = this.gameObject.GetComponent<Rigidbody>().velocity.z;
            //  float h = rigidbody.velocity;
            //float v = Input.GetAxis("Mouse Y");
           Vec1[2] =  ivmeX ;
            Vec1[0] = ivmez ;
           // Debug.Log("x" + ivmeX +"/n"+ "z" + ivmez );
        

        QVec1 = Quaternion.Euler(Vec1);
        AntenParca.targetRotation = QVec1;
		
	}
}
