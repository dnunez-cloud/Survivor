using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bandera es un componente del gameObject bandera
//su función es que cuando un Jugador coalisiona con el gameobject, le suma el valor de bandera a su contador de banderas.
public class Bandera : MonoBehaviour
{
    private int valorBandera = 1;

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<LogicaPuntaje>().incremento(valorBandera); //envía el valor de la variable a la función del otro componente
        Destroy(gameObject);  //destruye el objeto luego de la colisión
    }
}
