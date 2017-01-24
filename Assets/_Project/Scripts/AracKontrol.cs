using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AracKontrol : MonoBehaviour
{

    public GameObject basla;
    public bool akliVarmi = true; 
    public List<AksBilgisi> aksBilgileri; // Her ayrı aks için bilgi
    public float maksimumMotorTorku; // Motorun tekere uygulayabildiği maksimum güç
    public float maksimumTekerAcisi; // Tekerlerin Dönebileceği maksimum açı
    public float maksDevir = 100;
    public float stabilite = 0.3f;
    public float duzeltmeHizi = 2.0f;
    public float pitch;
    public float onMesafe;
    public float arkaMesafe;
    public float yukseklik;
    public GameObject hiz25;
    public GameObject hiz50;
    public GameObject hiz75;
    public GameObject hiz100;
    public float solCarpMes;
    public float sagCarpMes;
    public float carprazSolCarpMes;
    public float carprazSagCarpMes;
    public float carpmaKac;
    public float carpmaFren;
    public float carpmaYakinlik;
    public GameObject yonOk;
    public AudioClip gecis;
    AudioSource gecisSes;
    public int mevcutTur;
    public int hedefTur;
    public Transform oncekiNoktadaYon;
    private float oncekiKonumZaman;
    public float oncekiHiz;
    public GameObject GecisGoster;
    public float oncekiY;
    public TextMesh turUi;
    public TextMesh siraUi;
    public TextMesh bittiUi;
    public int neKadarOnde;
    public bool bitti = false;
    public int bittiSira;
    public GameObject fotoFinish;
    public int bitisSira;
    public GameObject solKutu;
    public GameObject sagKutu;
    public float bittiZaman;
    public GameObject KurtarmaUi;
    public GameObject collider1;
    






    public float maksHiz = 10;
    public float hiz;
    public float rpm;
    float yalpa;
    float yunuslama;
    float motor;
    float direksiyon;
    public float gaz;
    float sagSol;

    public Transform yol;
    public float yonlendir;
    public int noktaSayisi;

    private List<Transform> noktalar;
    private int siradakiHedef = 0;

    private void Start()
    {
        oncekiY = transform.rotation.y;
        Transform[] pathTransforms = yol.GetComponentsInChildren<Transform>();
        noktalar = new List<Transform>();
        siraUi.text = "Sıra \n 1-6";
        FotoFin fotoFinishScript = fotoFinish.GetComponent<FotoFin>();
        hedefTur = fotoFinishScript.hedefTur;
      //  Debug.Log("start" +hedefTur+ "tur");
        turUi.text = mevcutTur+ "/"+ hedefTur;

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != yol.transform)
            {
                
                noktalar.Add(pathTransforms[i]);
            }
        }
        noktaSayisi = pathTransforms.Length;
    }

    public void oyuncuAta()
    {
        akliVarmi = false;
    }
 
    public void Update()
    {

     /*   collectibleSence collectSense = collider1.GetComponent<collectibleSence>();
        int collect = collectSense.collectibleIden;
        if (collect == 1)
        {

        }*/
        yarisBasla basladimi = basla.GetComponent<yarisBasla>();
        bittiSira = bitisSira;
        bittiUi.text = bittiSira + ".";
       
        if (basladimi.basladimi == 1)
        { 
             if (akliVarmi)
             {
                  carpismaSezme();
                     yarimAkil();
                kurtarAi();
                turUi.gameObject.SetActive(false);
                siraUi.gameObject.SetActive(false);
                FotoFin fotoFinishScript = fotoFinish.GetComponent<FotoFin>();
                hedefTur = fotoFinishScript.hedefTur;
            }
             else
             {
                 kontrolGir();
                kurtarAi();
                turUi.gameObject.SetActive(true);
                siraUi.gameObject.SetActive(true);
                FotoFin fotoFinishScript = fotoFinish.GetComponent<FotoFin>();
                hedefTur = fotoFinishScript.hedefTur;
               
                turUi.text =  mevcutTur + "/" + hedefTur;
             
            }
             motorSesi();
             hizGosterge();
             siraBelirle();
            if (bittiZaman >= 5f && bittiZaman + 5f <= Time.time)
            {
                SceneManager.LoadScene("MainMenu");
                //Debug.Log("Returning");
            }
        }
    }
    public void FixedUpdate()
    {

        surus();
      /* yukseklikOlc();

        if ((yukseklik > 0.5f) && (yukseklik < 1f))
        {
            duzelt();
            
        }
        else if (yukseklik <= 0.3f)
        {
            surus();
        }
        else
        {
            akrobasi();
        }*/




    }

    private void carpismaSezme()
    {

         if (solCarpMes < carpmaYakinlik)
         {
             carpmaKac = 1f;
             if (solCarpMes < carpmaYakinlik/2)
                 carpmaFren = 0.5f;
         }
             else if (carprazSolCarpMes < carpmaYakinlik / 2)
         {
             carpmaKac = 0.5f;
         }

         if (sagCarpMes < carpmaYakinlik)
         {
             carpmaKac = -1f;
             if (sagCarpMes < carpmaYakinlik / 2)
                 carpmaFren = 0.5f;
         }
             else if(carprazSagCarpMes < carpmaYakinlik / 2)
         {
             carpmaKac = -0.5f;
         }
         /* if (carprazSolCarpMes < carpmaYakinlik / 2)
          {
              carpmaKac = 0.5f;           
          }*/
        /* if (carprazSagCarpMes < carpmaYakinlik / 2)
         {
             carpmaKac = -0.5f;
         }*/
        if (solCarpMes > carpmaYakinlik && sagCarpMes > carpmaYakinlik && carprazSolCarpMes > carpmaYakinlik && carprazSagCarpMes> carpmaYakinlik)
        {
            carpmaKac = 0f;
            carpmaFren = 0f;

        }
       /* collSensor solColl = solKutu.GetComponent<collSensor>();
        collSensor sagColl = sagKutu.GetComponent<collSensor>();
        if (solColl.engel)
        {
            carpmaKac = 1f;
            carpmaFren = 0.5f;
        }
        if (sagColl.engel)
        {
            carpmaKac = -1f;
            carpmaFren = 0.5f;
        }*/

    }


    private void yarimAkil()
    {
        Vector3 bagilRota = transform.InverseTransformPoint(noktalar[siradakiHedef].position);

        gaz = (((bagilRota.z - 0.1f ) / bagilRota.magnitude)   / 1.2f );
       
        if (gaz >= -0.01f && gaz <= 0.01f && bagilRota.magnitude > 1)
        {
            gaz = 0.5f;
        }
        if (gaz >= 0)
        {
            sagSol = (bagilRota.x / bagilRota.magnitude);
        }
         else
            sagSol = -(bagilRota.x / bagilRota.magnitude);
        




        if (bagilRota.magnitude < 1.5f)
        {
            oncekiNoktadaYon = transform;
            siradakiHedef = siradakiHedef + 1;
            if (siradakiHedef >= noktaSayisi - 1)
            {
                mevcutTur++;
                if (mevcutTur >= hedefTur)
                {
                    bitti = true;
                }
                siradakiHedef = 0;
            }
            oncekiY = transform.rotation.y;
        }
        

    }
    private void kurtarAi()
    {

        
        
       // float sonrakiHiz;
        if (oncekiKonumZaman == 0)
        {
            oncekiKonumZaman = Time.time;
            oncekiHiz = hiz;
           
        }
        if(oncekiKonumZaman + 3 <= Time.time)
        {
            if (Mathf.Abs(oncekiHiz) <= 0.1f && Mathf.Abs(hiz) <= 0.1f)
            {

                if (akliVarmi)
                {
                    if (siradakiHedef == 0)
                    {
                        transform.position = (noktalar[noktaSayisi - 2].position);

                    }
                    else
                    {
                        transform.position = (noktalar[siradakiHedef - 1].position);

                    }

                    transform.localEulerAngles = new Vector3(0, oncekiY * 180, 0);
                    oncekiKonumZaman = 0;
                }
                if (!akliVarmi)
                {
                    Debug.Log("kurtarma etkin");
                    KurtarmaUi.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.R))
                        {
                            if (siradakiHedef == 0)
                        {
                            transform.position = (noktalar[noktaSayisi - 2].position);

                        }
                            else
                        {
                            transform.position = (noktalar[siradakiHedef - 1].position);

                        }

                        transform.localEulerAngles = new Vector3(0, oncekiY * 180, 0);
                        oncekiKonumZaman = 0;
                        }
                    
                }

            }
            else
            {
                oncekiKonumZaman = 0;
                KurtarmaUi.gameObject.SetActive(false);
            }
        }
        

    }
    private void siraBelirle()
    {
        Vector3 bagilRota = transform.InverseTransformPoint(noktalar[siradakiHedef].position);
        int araMesafe = Mathf.RoundToInt(bagilRota.magnitude /4);
        neKadarOnde = (mevcutTur * 10000) + (siradakiHedef * 100) - (araMesafe);
       
    }
    private void kontrolGir()
    {
        sagSol = Input.GetAxis("Horizontal");
        gaz = Input.GetAxis("Vertical");

      

        Vector3 bagilRota = transform.InverseTransformPoint(noktalar[siradakiHedef].position);

        if (bagilRota.magnitude < 1.5f)
        {
            siradakiHedef = siradakiHedef + 1;
            gecisSes = transform.GetComponent<AudioSource>();
            gecisSes.PlayOneShot(gecis, 1F);
            if (siradakiHedef >= noktaSayisi - 1)
            {
                mevcutTur++;
                if (mevcutTur >= hedefTur && (!bitti))
                {
                    FotoFin fotoFinishScript = fotoFinish.GetComponent<FotoFin>();
                    hedefTur = fotoFinishScript.hedefTur;
                    bitti = true;
                    akliVarmi = true;
                    bittiUi.gameObject.SetActive(true);
                    bittiZaman = Time.time;
                  //  Debug.Log(bittiZaman);
                }
                
                turUi.text = mevcutTur + "/" + hedefTur;
                siradakiHedef = 0;
            }
            oncekiY = transform.rotation.y;
        //    Debug.Log(oncekiY);
        }
        yonOk.gameObject.SetActive(true);
        yonOk.transform.LookAt(noktalar[siradakiHedef].position);
        GecisGoster.gameObject.SetActive(true);
        GecisGoster.transform.position = noktalar[siradakiHedef].position;
        GecisGoster.transform.rotation = Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(1000 * Vector3.up);
        }
    }

    private void yukseklikOlc()
    {
        if (onMesafe > arkaMesafe)
        {
            yukseklik = onMesafe;
        }
        else
        {
            yukseklik = arkaMesafe;
        }
    }


    private void surus()
    {
       // yunuslama = gaz ;
       yunuslama = Mathf.Lerp(0, gaz, Time.deltaTime *50);

        if (carpmaKac == 0f)
        {
            yalpa = sagSol;
        }
        else
        {
            yalpa = carpmaKac;
            gaz = gaz - carpmaFren;
        }
        

      //motor = Mathf.Clamp((motor + (maksimumMotorTorku * yunuslama)*Time.deltaTime), -maksimumMotorTorku, maksimumMotorTorku)*Mathf.Abs(yunuslama);
     // direksiyon = Mathf.Clamp(( direksiyon + (maksimumTekerAcisi * yalpa)*Time.deltaTime) , -maksimumTekerAcisi , maksimumTekerAcisi)* Mathf.Abs(yalpa);
      direksiyon = yalpa * maksimumTekerAcisi;
       motor = yunuslama * maksimumMotorTorku;
        foreach (AksBilgisi aksBilgisi in aksBilgileri)
        {
            if (aksBilgisi.direksiyon)
            {
                aksBilgisi.solTeker.steerAngle = direksiyon ;
                aksBilgisi.sagTeker.steerAngle = direksiyon ;
            }
            if (aksBilgisi.motor)
            {
                aksBilgisi.solTeker.motorTorque = motor;
                if (Mathf.Abs(aksBilgisi.solTeker.rpm) > maksDevir)
                    aksBilgisi.solTeker.motorTorque = 0;
                aksBilgisi.sagTeker.motorTorque = motor;
                if (Mathf.Abs(aksBilgisi.sagTeker.rpm) > maksDevir)
                    aksBilgisi.sagTeker.motorTorque = 0;
            }
            TekerPoziyonunuGorunumeUygula(aksBilgisi.solTeker);
            TekerPoziyonunuGorunumeUygula(aksBilgisi.sagTeker);
            rpm = Mathf.Abs(aksBilgisi.sagTeker.rpm);
        }
    }
    private void akrobasi()
    {

        GetComponent<Rigidbody>().AddTorque(yalpa * -transform.forward * duzeltmeHizi);
        GetComponent<Rigidbody>().AddTorque(yunuslama * transform.right * duzeltmeHizi);
    }

    private void duzelt()
    {

        Vector3 varsayilanYukari = Quaternion.AngleAxis(
           GetComponent<Rigidbody>().angularVelocity.magnitude * Mathf.Rad2Deg * stabilite / duzeltmeHizi,
           GetComponent<Rigidbody>().angularVelocity) * transform.up;
        Vector3 duzeltmeEtkisi = Vector3.Cross(varsayilanYukari, Vector3.up);
        GetComponent<Rigidbody>().AddTorque(duzeltmeEtkisi * duzeltmeHizi * duzeltmeHizi);
    
    }
    private void motorSesi()
    {

        hiz = GetComponent<Rigidbody>().velocity.magnitude;

        pitch = Mathf.Clamp(/*Mathf.Abs(yunuslama) **/ hiz / maksHiz, 0.05f, 0.9f);

        transform.GetComponent<AudioSource>().pitch = pitch;
       
    
    }
    public void TekerPoziyonunuGorunumeUygula(WheelCollider teker)
    {
        if (teker.transform.childCount == 0)
        {
            return;
        }

        Transform gorunenTeker = teker.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        teker.GetWorldPose(out position, out rotation);

        gorunenTeker.transform.position = position;
        gorunenTeker.transform.rotation = rotation;
    }

    private void hizGosterge()
    {
        if (hiz > 1)
        {
            hiz25.SetActive(true);
        }
        if (hiz < 1)
        {
            hiz25.SetActive(false);
        }
        if (hiz > (maksHiz/4))
        {
            hiz50.SetActive(true);
        }
        if (hiz < (maksHiz / 4))
        {
            hiz50.SetActive(false);
        }
        if (hiz > (maksHiz / 2))
        {
            hiz75.SetActive(true);
        }
        if (hiz < (maksHiz / 2))
        {
            hiz75.SetActive(false);
        }
        if (hiz > (maksHiz - 2))
        {
            hiz100.SetActive(true);
        }
        if (hiz < (maksHiz - 2))
        {
            hiz100.SetActive(false);
        }
    }


}
[System.Serializable]
public class AksBilgisi
{
    public WheelCollider solTeker;
    public WheelCollider sagTeker;
    public bool motor; // Tekerler Bir Motora Bağlımı?
    public bool direksiyon; // Tekerlere yönlendirme  için kullanılıcakmı?
}
