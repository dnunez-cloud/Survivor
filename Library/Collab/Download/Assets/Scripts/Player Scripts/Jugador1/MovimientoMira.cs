using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
//componente del objeto jugador que le da control de la mira

public class MovimientoMira : MonoBehaviour
{
    public Transform jugadorRaiz;

    [SerializeField]
    private float sensibilidad = 1.5f;

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
        actualMiraMouse = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        miraAngulos.x -= actualMiraMouse.x * sensibilidad;
        miraAngulos.y += actualMiraMouse.y * sensibilidad;

        miraAngulos.x = Mathf.Clamp(miraAngulos.x, miraLimiteDefault.x, miraLimiteDefault.y); // el segundo y tercer parametros no van a permitir que el primer parametro supere los limites establecidos
        jugadorRaiz.localRotation = Quaternion.Euler(miraAngulos.x, miraAngulos.y, 0f);
    }
}
