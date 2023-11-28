using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabInfoPlayer : MonoBehaviour
{
    private static RectTransform rectTransform;
    private static Transform txt_nickname;
    private static Transform txt_score;
    private static TMP_Text textoHijo1;
    private static TMP_Text textoHijo2;
    private void Awake()
    {
        // Obtén la referencia al componente RectTransform de la imagen
        rectTransform = GetComponent<RectTransform>();

        // Encuentra los hijos por nombre
        txt_nickname = rectTransform.Find("txt_nickname");
        txt_score = rectTransform.Find("txt_score");

        // Asigna valores a los Text component de los hijos
        textoHijo1 = txt_nickname.GetComponent<TMP_Text>();
        textoHijo2 = txt_score.GetComponent<TMP_Text>();


    }

    public void  establecerValoresTXT(string sNickname, string sCore)
    {
        // Verifica si los hijos se encontraron antes de intentar asignarles valores
        if (txt_nickname != null && txt_score != null)
        {
            // Asigna valores a los Text component de los hijos
            TMP_Text textoHijo1 = txt_nickname.GetComponent<TMP_Text>();
            TMP_Text textoHijo2 = txt_score.GetComponent<TMP_Text>();

            if (textoHijo1 != null && textoHijo2 != null)
            {
                // Asigna valores a los Text component
                textoHijo1.text = sNickname;
                textoHijo2.text = sCore;
            }
            else
            {
                Debug.LogError("Los hijos no tienen componentes de texto.");
            }
        }
        else
        {
            Debug.LogError("No se encontraron los hijos con los nombres especificados.");
        }
    }
}
