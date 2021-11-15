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
        tiempo = cambioescena.tiempoFin;
        int min = Mathf.FloorToInt(tiempo / 60);
        int sec = Mathf.FloorToInt(tiempo % 60);
        tiempos = min.ToString("00") + ":" + sec.ToString("00");
        texto.text = "" + tiempos ;
    }
}
