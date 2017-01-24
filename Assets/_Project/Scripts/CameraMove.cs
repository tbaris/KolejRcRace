using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float hassaslik = 100.0f;
    public float aci = 80.0f;

    private float y_donus = 0.0f;
    private float x_donus = 0.0f;

    void Start()
    {
        Vector3 donus = transform.localRotation.eulerAngles;
        y_donus = donus.y;
        x_donus = donus.x;
    }

    void Update()
    {
        float fare_x = Input.GetAxis("Mouse X");
        float fare_y = -Input.GetAxis("Mouse Y");

        y_donus += fare_x * hassaslik * Time.deltaTime;
        x_donus += fare_y * hassaslik * Time.deltaTime;

        x_donus = Mathf.Clamp(x_donus, -aci, aci);

        Quaternion localRotation = Quaternion.Euler(x_donus, y_donus, 0.0f);
        transform.rotation = localRotation;
    }
}
