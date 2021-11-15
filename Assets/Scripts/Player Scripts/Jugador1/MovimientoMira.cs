using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
//componente del objeto jugador que le da control de la mira

public class MovimientoMira : MonoBehaviour
{
    public Transform jugadorRaiz;

    public float sensibilidad = 1.5f;

    private Vector2 miraAngulos;

    private Vector2 actualMiraMouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;                  //oculta el cursor
    }

    // Update is called once per frame
    void Update()
    {
     MirarAlrededor();
    }

    void MirarAlrededor()               //función que permite el movimiento de la mira en el jugador
    {
        actualMiraMouse = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X)); //el vector toma los axis de movimiento X, Y 

        miraAngulos.x -= actualMiraMouse.x * sensibilidad;                            //guarda en el vector el producto del vector actualmiramouse por la sensibilidad
        miraAngulos.y += actualMiraMouse.y * sensibilidad;
        miraAngulos.x = Mathf.Clamp(miraAngulos.x, -40f, 40f);               //en este vector en particular aplica límites para que solo se pueda mover dentro del rango
        jugadorRaiz.localRotation = Quaternion.Euler(miraAngulos.x, miraAngulos.y, 0f); //le dará la rotación de los ángulos de la mira al jugador
    }
}
