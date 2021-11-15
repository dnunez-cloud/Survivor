using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto ParedL que se levanta. Hace que suba de un punto a otro cuando es colisionado por la rollerball, 
//también le quita la vida al jugador si este la toca

public class ParedLevanta : MonoBehaviour
{
    private float mover = 4f;
    public bool subiendo = false;
    public Vector3 nuevaPosicion;
    public int valorDaño = -100;

    // Start is called before the first frame update
    void Start()
    {
        nuevaPosicion = new Vector3(220, 4, 489); //setea la posición en la que se encontrará inicialmente el objeto
        transform.position = nuevaPosicion; //carga la posición seteada en el objeto
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(nuevaPosicion.x, mover, nuevaPosicion.z);//moverá la posición del objeto dependiendo si el bool "subiendo" ha sido cambiado a true
        if (subiendo == true)
        {
            mover += 0.1f;
            if (mover > 12)
            { subiendo = false; }
        }
    }
    public void incremento(bool valor)
    {
        subiendo = valor; //recogerá el valor bool recibido y lo asignará el la variable de control
    }
    public void OnTriggerEnter(Collider other) 
    {
        try {other.GetComponent<Vida>().incremento(valorDaño);} //detecta si el jugador ha tocado la pared ocasionandole un daño.
        catch (System.NullReferenceException) {}
    }
}
