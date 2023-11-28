using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Navegacion : MonoBehaviour
{
    // Start is called before the first frame update
    public void irLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void irRegistro()
    {
        SceneManager.LoadScene("Registro");
    }

    public void irInicio()
    {
        //try
        //{
        //    DatosPlayer oDatosPlayer = DatosPlayer.DatosPlayerinstance;
        //    oDatosPlayer.DestruirDatosPlayer();
        //}
        //catch (System.Exception)
        //{ }

        SceneManager.LoadScene("MainMenu");
    }


    public void irScore()
    {
        SceneManager.LoadScene("Score");
    }


}
