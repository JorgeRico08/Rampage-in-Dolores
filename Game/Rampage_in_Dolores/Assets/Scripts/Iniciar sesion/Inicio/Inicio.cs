using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{

    public GameObject botonesSesion;
    public GameObject botonScore;
    public GameObject alerta;
    private Session _session;

    //[SerializeField] private TMP_Text textoWelcome;

    private void Awake()
    {
        Time.timeScale = 1f;
        _session = Session.Sessioninstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        mostrarBotones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarBotones()
    {
        if (_session.isLogin())
        {
            //if (_session.sNickname != "")
            //{
            //    textoWelcome.text = "Hola: " + _session.sNickname;
            //}
            botonesSesion.SetActive(false);
            botonScore.SetActive(true);
        }
        else
        {
            botonesSesion.SetActive(true);
            botonScore.SetActive(false);
        }
    }

    public void cerrarSesionInicio()
    {
        _session.cerrarSesion();
        botonesSesion.SetActive(true);
        botonScore.SetActive(false);
    }

    public void validarInicioSesion()
    {
        if (_session.isSesion == true)
        {
            SceneManager.LoadScene("cinOficinaTurismo");
        }
        else
        {
            alerta.SetActive(true);
        }
    }

    public void validarInicioSesionOmitir()
    {
        if (_session.isSesion == true)
        {
            SceneManager.LoadScene("Nivel 1");
        }
        else
        {
            alerta.SetActive(true);
        }
    }

    public void ocultarAlertaInicioSesion()
    {
        alerta.SetActive(false);
    }
}
