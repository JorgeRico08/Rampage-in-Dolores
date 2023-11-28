using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Session : MonoBehaviour
{
    public static Session Sessioninstance;
    public bool isSesion { get; set; } = false;

    public string sNickname { get; set; } = "";

    public string sID { get; set; } = "";

    private void Awake()
    {
        if (Sessioninstance == null)
        {
            Sessioninstance = this;
            DontDestroyOnLoad(Sessioninstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public bool isLogin()
    {
        return Sessioninstance.isSesion;
    }

    public void setLogin(bool valor)
    {
        Sessioninstance.isSesion = valor;
    }

    public void setNickname(string valor)
    {
        Sessioninstance.sNickname = valor;
    }

    public void setID(string valor)
    {
        Sessioninstance.sID = valor;
    }


    public void cerrarSesion()
    {
        Sessioninstance.isSesion = false;
        Sessioninstance.sNickname = "";
        Sessioninstance.sID = "";
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
