using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;
using TMPro;

public class NavegacionJuego : MonoBehaviour
{
    [SerializeField] private TMP_Text txtScore;

    private bool isPaused = false;
    private DatosPlayer datosPlayer;
    public GameObject gameOver;

    public RectTransform heardUI;

    private bool isGameOver = false;

    private void Awake()
    {
        datosPlayer = DatosPlayer.DatosPlayerinstance;
        heardUI = GetComponent<RectTransform>();
    }

    void Start()
    {

    }

    void Update() 
    {
        txtScore.text = datosPlayer.getPuntuacion().ToString();

        if (datosPlayer.getVida() < 1 && isGameOver == false)
        {
            isGameOver = true;
            datosPlayer.desactivarPlayer();

            DBMongo.ActualizarScore(datosPlayer.getPuntuacion());
            mostrarGameOver();
            this.pausa();
        }
    }

    public void reiniciar()
    {
            Time.timeScale = 1f;
            datosPlayer.retry();
            datosPlayer.DestruirDatosPlayer();
            SceneManager.LoadScene(1);
    }

    public void irInicio()
    {
        try
        {
            DatosPlayer oDatosPlayer = DatosPlayer.DatosPlayerinstance;
            oDatosPlayer.DestruirDatosPlayer();
        }
        catch (System.Exception)
        {
            Debug.Log("Error");
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void continuar()
    {
        SceneManager.LoadScene("TodoTermino");
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

    public void mostrarGameOver()
    {
        gameOver.SetActive(true);
    }


}
