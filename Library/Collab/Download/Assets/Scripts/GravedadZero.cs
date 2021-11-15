using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento gravedad zero, 
//Deshabilita MovimientoJugador y habilita MovimientoSinGravedad para poder controlar su gravedad y movimientos.
//También cambia el booleano "sin gravedad" para activar el impulso con el raycast.
public class GravedadZero : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        try
        {
         other.GetComponent<MovimientoJugador>().enabled = false;
         other.GetComponent<MoverSinGravedad>().enabled = true;
         other.GetComponent<MoverSinGravedad>().singravedad = true;
        }
        catch (System.NullReferenceException){ }
        try
        {
         other.GetComponent<MovimientoJugador2>().enabled = false;
         other.GetComponent<MoverSinGravedad2>().enabled = true;
         other.GetComponent<MoverSinGravedad2>().singravedad = true;

        }
        catch (System.NullReferenceException) {}      
    }
    public void OnTriggerExit(Collider other)
    {
        try
        {
         other.GetComponent<MovimientoJugador>().enabled = true;
         other.GetComponent<MoverSinGravedad>().enabled = false;
         other.GetComponent<MoverSinGravedad>().singravedad = false;
        }
        catch (System.NullReferenceException) {}
        try
        {
         other.GetComponent<MovimientoJugador2>().enabled = true;
         other.GetComponent<MoverSinGravedad2>().enabled = false;
         other.GetComponent<MoverSinGravedad2>().singravedad = false;
        }
        catch (System.NullReferenceException){}
    }
}
