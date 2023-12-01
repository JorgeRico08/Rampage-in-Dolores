using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configLevel2 : MonoBehaviour
{
    private DatosPlayer datosPlayer;
    private bool isAcaboNivel = false;
    public GameObject alertaWin;

    private bool isPaused = false;

    void Start()
    {
        datosPlayer = DatosPlayer.DatosPlayerinstance;
        DatosPlayer.reasignarJugador();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAcaboNivel)
        {
            pausa();
            isAcaboNivel = true;
            Debug.Log("Acabo nivel");

            // Acciones adicionales
            alertaWin.SetActive(true);
            DBMongo.ActualizarScore(datosPlayer.getPuntuacion());

        }
    }

    public void pausa()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el tiempo en el juego
        }
        else
        {
            Time.timeScale = 1f; // Restaura el tiempo normal en el juego
        }
    }

}
