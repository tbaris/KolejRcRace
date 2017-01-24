using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomFov : MonoBehaviour
{
    public float min_fov = 30f;
    public float maks_fov = 90f;
    public float hassaslik = 10f;

    void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * hassaslik;
        fov = Mathf.Clamp(fov, min_fov, maks_fov);
        Camera.main.fieldOfView = fov;
    }
}
