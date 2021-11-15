using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto plataforma que hace que se mueva de un punto a otro
public class Plataforma : MonoBehaviour
{
    private float mover = 503;
    public bool moviendo = true;
    public Vector3 nuevaPosicion;
    // Start is called before the first frame update
    void Start()
    {
        nuevaPosicion = new Vector3(41, 9, 454); //setea la posición desde donde se va a localizar la plataforma 
        transform.position = nuevaPosicion; //carga la posición seteada en la posición del objeto cuando comienza el juego
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(nuevaPosicion.x, nuevaPosicion.y,  mover); //moverá la posición del objeto dependiendo si llegó a un extremo o el otro
        if (moviendo == true)
        {
            mover += 0.1f;
            if (mover > 503)
            { moviendo = false; }
        }
        else if (moviendo == false)
        {
            mover -= 0.1f;
            if (mover < 454) { moviendo = true; }
        }
    }
}
