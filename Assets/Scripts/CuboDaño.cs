using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//componente del elemento puertaZombie, destruye la misma cuando el jugador le dispara ya que detecta si recibió el disparo por el descenso a 0 de su vida.

public class CuboDaño : MonoBehaviour
{
    public Vida vida;
    public bool vida0 = false;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>(); //cargara en la variable el componente
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida(); 
    }
    void RevisarVida()   //función que revisa si la vida llegó a 0
    {
        if (vida0) return;
        if (vida.valor <= 0)
        {
            vida0 = true;
            Destroy(gameObject, 0.1f);
        }
    }
}
