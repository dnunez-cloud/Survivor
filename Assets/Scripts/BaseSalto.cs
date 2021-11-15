using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//componente del elemento base de salto, 
//multiplica la fuerza del salto del jugador haciendo que llegue a puntos mas altos.
public class BaseSalto : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        try{ other.GetComponent<MovimientoJugador>().salto = 20;}
        catch (System.NullReferenceException){}
        try {other.GetComponent<MovimientoJugador2>().salto = 20;}
        catch (System.NullReferenceException) {}
    }
    public void OnTriggerExit(Collider other)
    {
        try { other.GetComponent<MovimientoJugador>().salto = 10;}
        catch (System.NullReferenceException){}
        try{other.GetComponent<MovimientoJugador2>().salto = 10;}
        catch (System.NullReferenceException) {}
    }
}

