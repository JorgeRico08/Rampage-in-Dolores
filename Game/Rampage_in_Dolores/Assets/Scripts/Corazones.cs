using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{
    // Start is called before the first frame update

    public static RectTransform heardUI;
    private DatosPlayer _datosPlayer;

    private void Awake()
    {

    }

    private void Start()
    {
        heardUI = GetComponent<RectTransform>();
        _datosPlayer = DatosPlayer.DatosPlayerinstance;
        heardUI.sizeDelta = new Vector2(23f * _datosPlayer.getVida(), 23f);
    }


    public static void resetSize(int iTotalVidas)
    {
        heardUI.sizeDelta = new Vector2(23f * iTotalVidas, 23f);
    }
}
