using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShower : MonoBehaviour {

    public GameObject Canvas;
    private bool basladi = false;
    private bool durdu = false;

    void Update()
    {
        basladi = false;
        if (Input.GetKeyDown(KeyCode.Escape) && !basladi && !durdu)
        {
            Canvas.SetActive(true);
            Cursor.visible = true;
            durdu = true;
            basladi = true;
        }

        if (durdu)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !basladi)
            {
                Canvas.SetActive(false);
                Cursor.visible = false;
                durdu = false;
                basladi = true;
                imlecKapa();
            }
        }
      
    }
    public void imlecKapa()
    {
        Cursor.visible = false;
    }
}
