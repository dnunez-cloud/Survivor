using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//elemento del componente canva Tiempo que muestra el tiempo de la partida expresado en minutos y segundos
public class PantallaTiempo : MonoBehaviour
{
    public Text texto;
    public CambioEscena cambioescena;
    public float tiempo;
    public string tiempos;
  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = cambioescena.tiempoFin;           //asigna a la variable el elemento del componente cambio escena, que contiene el tiempo actual
        int min = Mathf.FloorToInt(tiempo / 60);  //divide el tiempo por 60 para sacar cantidad de minutos del tiempo actual
        int sec = Mathf.FloorToInt(tiempo % 60); //realiza calculo para sacar los segundos exactos del tiempo actual
        tiempos = min.ToString("00") + ":" + sec.ToString("00");  //cambia la forma de expresar el valor guardado en la variable en minutos y segundos
        texto.text = "" + tiempos ;                              // Muestra en el texto la variable expresada como se desea  
    }
}
