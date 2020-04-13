using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{

    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;


    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    int contadorCalles = 0;
    int numeroSelectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamanhoCalle;

    public Vector3 medidaLimitePantalla;
    public bool salioPantalla;
    public GameObject mCamGo;
    public Camera mCampComp;

    public GameObject cocheGO;
    public GameObject audioFXGO;
    public AudioFX audioFXSCript;
    public GameObject bgFinalGO;

    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCampComp = mCamGo.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);
        
        audioFXGO = GameObject.Find("AudioFX");
        audioFXSCript = audioFXGO.GetComponent<AudioFX>();

        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;

        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
    }

   public void JuegoTerminadoEstados()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXSCript.FXMusic();
        bgFinalGO.SetActive(true);
    }


    void VelocidadMotorCarretera()
    {
        velocidad = 18;
    }

    void BuscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        int i = 0;
        foreach (var gameObject in contenedorCallesArray)
        {
            gameObject.transform.parent = contenedorCallesGO.transform;
            gameObject.SetActive(false);
            gameObject.name = "CalleOF_" + i++;
        }

        CrearCalles();
    }

    void CrearCalles()
    {
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);
        GameObject calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        calle.SetActive(true);
        calle.name = "Calle" + contadorCalles;
        calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamanhoCalle, 0);
        salioPantalla = false;


    }

    void MidoCalle()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamanhoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamanhoCalle = tamanhoCalle + tamanhoPieza;
            }
        }
   
    }

    // Start is called before the first frame update
    void Start()
    {
        InicioJuego();
        
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCampComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego && !juegoTerminado)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);

            if (calleAnterior.transform.position.y + tamanhoCalle < medidaLimitePantalla.y && !salioPantalla)
            {
                salioPantalla = true;
                DestruyoCalles();
            }

        }

       
    }

    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        tamanhoCalle = 0;
        calleAnterior = null;
        CrearCalles();
      
    }
}
