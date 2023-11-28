using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Registro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botonEnviar;
    public GameObject alerta;
    // Referencia al texto del panel
    [SerializeField] private TMP_Text textoNickname;

    [SerializeField] private TMP_InputField textoPassword;

    [SerializeField] private TMP_Text textoAlerta;

    private void Awake()
    {

    }


    public void validacion()
    {
        string sResultado = "-1";
        string sNick = Regex.Replace(textoNickname.text, @"[\s]+", "");
        string sPass = textoPassword.text;
        Debug.Log(sPass);
        string expresionRegular = @"^(?=.*[0-9])(?=.*[A-Z])(?=.*[#$%_!]).{8,}$";
        if (sNick.Length == 1)
        {
            textoAlerta.text = "Nombre de usuario obligatorio";
            if (alerta.activeSelf == false)
            {
                alerta.SetActive(true);
            }
        }
        else if (sPass.Length == 1)
        {
            textoAlerta.text = "Contraseña obligatoria";
            if (alerta.activeSelf == false)
            {
                alerta.SetActive(true);
            }
        }
        else if (!Regex.IsMatch(sPass, expresionRegular))
        {
            textoAlerta.text = "La contraseña no es válida";
            if (alerta.activeSelf == false)
            {
                alerta.SetActive(true);
            }
        }
        else
        {

            alerta.SetActive(false);
            sResultado = DBMongo.RegisterUser(sNick, sPass);
            if (sResultado == null)
            {
                SceneManager.LoadScene("Login");
            }
            else
            {
                textoAlerta.text = sResultado;
                alerta.SetActive(true);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
