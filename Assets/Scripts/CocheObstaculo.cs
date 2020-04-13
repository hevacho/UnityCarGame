using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{

    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFX;
    public AudioFX audioFXSCript;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coche>() != null)
        {
            Destroy(this.gameObject);
            audioFXSCript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = GameObject.FindObjectOfType<Cronometro>();

        audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXSCript = GameObject.FindObjectOfType<AudioFX>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
