using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
//componente del objeto jugador que le da el movimiento de la mira

public class MovimientoMira2 : MonoBehaviour
{
    public Transform jugadorRaiz;

    [SerializeField]
    private float sensibilidad = 10f;

    [SerializeField]
    private Vector2 miraLimiteDefault = new Vector2(-70f, 80f);

    private Vector2 miraAngulos;

    private Vector2 actualMiraMouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
     MirarAlrededor();
    }

    void MirarAlrededor()
    {
        actualMiraMouse = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y1), Input.GetAxis(MouseAxis.MOUSE_X1));

        miraAngulos.x -= actualMiraMouse.x * sensibilidad;
        miraAngulos.y += actualMiraMouse.y * sensibilidad;
        jugadorRaiz.rotation = Quaternion.Euler(miraAngulos.x, miraAngulos.y, 0f);
    }
}