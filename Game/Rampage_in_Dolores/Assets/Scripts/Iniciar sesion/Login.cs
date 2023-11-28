using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_Text textoNickname;

    [SerializeField] private TMP_InputField textoPassword;

    [SerializeField] private TMP_Text textoAlerta;

    public GameObject alerta;

    public GameObject ventanaCargando;

    private string _sRespuesta;

    public async void inicarSesion()
    {
        ventanaCargando.SetActive(true);
        _sRespuesta = await DBMongo.login(textoNickname.text, textoPassword.text);
        ventanaCargando.SetActive(false);
        if (_sRespuesta == "OK")
        {
            alerta.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            textoAlerta.text = _sRespuesta;
            alerta.SetActive(true);
        }
    }
}
