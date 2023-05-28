using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateDePlayer : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximaVida;
    [SerializeField] private BarraDeVida barraDeVida;



    private void Start()
    {
        vida = maximaVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }


    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Curar(float curacion)
    {
        if ((vida + curacion) > maximaVida)
        {
            vida = maximaVida;
        }
        else
        {
            vida += curacion;
        }
    }
}
