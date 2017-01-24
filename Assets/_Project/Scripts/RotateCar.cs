using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RotateCar : MonoBehaviour {

    public GameObject car0;

    void Update () {
        Cursor.visible = true;
        car0.transform.Rotate(0f, 1f, 0f);
    }
}
