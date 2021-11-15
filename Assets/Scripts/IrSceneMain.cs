using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//componente de objeto manejador en la scene de Fin de juego. Si el jugador elige iniciar nueva partida iniciará la escena principal, si presiona quit saldrá del juego.
public class IrSceneMain : MonoBehaviour
{
    public void cargarscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void salir()
    {
        Application.Quit();
    }
}
