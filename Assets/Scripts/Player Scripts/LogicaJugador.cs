using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//componente del objeto jugador que contabiliza la vida del jugador y a su vez detecta cuando el jugador murió porque su vida llegó a 0
public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool vida0 = false;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();  //asigna su componente vida a la variable para ser modificada
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();  //función que revisa si la vida del jugador llegó a cero
    }
    void RevisarVida()
    {
        if (vida0) return;
        if (vida.valor <= 0)
        {
            vida0 = true;
        }
    }
}
