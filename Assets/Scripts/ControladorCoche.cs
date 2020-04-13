using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject cocheGO;

    public float anguloDeGiro;
    public float velocidad;

    public TouchControl botonDerecha;
    public TouchControl botonIzquierda;

    // Start is called before the first frame update
    void Start()
    {
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
        velocidad = 15;
        anguloDeGiro = -45;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float direccion;
        if (botonIzquierda.pulsado)
        {
            direccion = -1;
        }else if (botonDerecha.pulsado)
        {
            direccion = 1;
        }
        else
        {
            direccion = Input.GetAxis("Horizontal");
        }

        float giroEnZ = 0;
        
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        giroEnZ = direccion * anguloDeGiro;
        cocheGO.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);
        
    }
}
