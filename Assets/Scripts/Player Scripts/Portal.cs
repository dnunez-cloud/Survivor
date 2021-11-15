using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del objeto jugador que detecta cuando coalisionó con el gameobject portal y hace que se transforme su posición llevandolo al otro punto del portal
public class Portal : MonoBehaviour
{
    public Transform portal;
    public int valor;
    public Transform posicionJugador;

    // Update is called once per frame
    void Update()
    {
        if (valor== 1) //detecta si recibió el valor
        {
            Mover();
            valor = 0;
        }
    }
    public void incremento(int valorP)
    {
        valor = valorP; //recibe el valor del trigger del objeto portal y lo asigna en la variable de control
    }
    public void Mover()  //función que mueve la posición del player a la posición destino del portal
    {
        //debido a un bug de unity en FPS charactercontroller, al hacer respawn se deshabilitaba el charactercontroller, por lo cual hay que reinicializarlo
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        posicionJugador.transform.position = portal.transform.position;
        cc.enabled = true;
    }
}
