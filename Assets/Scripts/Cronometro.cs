using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarrerasScript;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGO = GameObject.Find("MotorCarretera");
        motorCarrerasScript = motorCarreterasGO.GetComponent<MotorCarreteras>();
        txtTiempo.text = "2:00";
        txtDistancia.text = "0";
        tiempo = 120;



    }

    // Update is called once per frame
    void Update()
    {
        if(motorCarrerasScript.inicioJuego && !motorCarrerasScript.juegoTerminado)
        {
            CalculoTiempoDistancia();
        }
        if(tiempo<=0 && !motorCarrerasScript.juegoTerminado)
        {
            motorCarrerasScript.juegoTerminado = true;
            motorCarrerasScript.JuegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)distancia).ToString() +" MTS";
            txtTiempo.text = "0:00";

        }
        
    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * motorCarrerasScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();
        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');

    }
}
