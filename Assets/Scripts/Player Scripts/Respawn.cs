using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento Jugador que hará respawn cuando el jugador se cae del mapa o cuando su vida llega a 0
public class Respawn : MonoBehaviour
{
    public Transform respawn; 
    public Transform posicionJugador;
    public Vida vida;
    private int penalidad = 1;
    // Update is called once per frame
    void Update()
    {
        if (JugadorCaido())   //verifica el resultado de la función, si da true sigue con la función respawnear.
        {
            Respawnear();
        }
        if (vida.valor <=0)  //verifica si la vida del jugador ha llegado a cero.
        {
            Respawnear();
            //Cuando el jugador moría en el area de gravedad zero por no tener mas vida, los scripts no se cambiaban, por lo tanto se deben reiniciar cuando el jugador muere
            try
            {
                gameObject.GetComponent<MovimientoJugador>().enabled = true;
                gameObject.GetComponent<MoverSinGravedad>().enabled = false;
                gameObject.GetComponent<MoverSinGravedad>().singravedad = false;
            }
            catch (System.NullReferenceException) { }
            try
            {
                gameObject.GetComponent<MovimientoJugador2>().enabled = true;
                gameObject.GetComponent<MoverSinGravedad2>().enabled = false;
                gameObject.GetComponent<MoverSinGravedad2>().singravedad = false;
            }
            catch (System.NullReferenceException) { }
        }
    }

    public void Respawnear()
    {
        //debido a un bug de unity en FPS charactercontroller, al hacer respawn se deshabilitaba el charactercontroller, por lo cual hay que reinicializarlo
        CharacterController cc = GetComponent<CharacterController>();
        cc.enabled = false;
        posicionJugador.transform.position = respawn.transform.position;     //manda al jugador a la ubicación donde hace el respawn
        cc.enabled = true;
        vida.valor = 100;                                                  //reinicia el valor de la vida del jugador
        gameObject.GetComponent<LogicaPuntaje>().incremento(-penalidad);  //le resta la penalidad al puntaje del jugador
        gameObject.GetComponent<LogicaJugador>().vida0 = false;          //cambia el valor booleano de la vida del jugador, para que el enemigo active nuevamente la búsqueda
    }

    private bool JugadorCaido()
    {
        return posicionJugador.position.y < -0.5;   //verifica si el jugador ha caído del plano
    }
}
