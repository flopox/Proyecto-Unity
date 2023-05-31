using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public int PuntosTotales{ get; private set; }

    public HUD hud;

    private int vidas = 5;

    private void Awake(){
        if(Instance == null){
        Instance = this;
        } else {
        Debug.Log("Mas de un GameManager en escena!");
        }
    }
    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
        hud.ActualizacionPuntos(PuntosTotales);
    }
    public void PerderVidas()
    {
        vidas -= 1;

        if(vidas == 0)
        {
            SceneManager.LoadScene(2);
        }

        hud.DesactivarVidas(vidas);
    }

    public bool RecuperarVidas()
    {
        if(vidas == 5)
        {
            return false;
        }

        hud.ActivarVidas(vidas);
        vidas += 1;
        return true;
    }
}
