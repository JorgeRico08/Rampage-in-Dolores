using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.PlayerSettings;

public class Score : MonoBehaviour
{
    // Referencia al texto del panel
    [SerializeField] private TMP_Text textoDialogo;

    public Transform scrollViewContentTransform;

    public GameObject prefabDeUsuario;
    private List<ModelPlayer> _playersScore;

    [SerializeField] private GameObject imagenError;

    float alturaElemento = 50f; // Ajusta esto según la altura de tu prefab
    float separacionVertical = 10f; // Ajusta esto según la separación que desees
    private Vector3 posicion;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            textoDialogo.text = DBMongo.ObtenerScorePorIdPlayer().ToString();
            listarPlayerScore();
        }
        catch (Exception)
        {
            imagenError.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void listarPlayerScore()
    {
        _playersScore = DBMongo.ConsultarTodosRegistros();

        int index = 0;
        foreach (var usuario in _playersScore)
        {
            posicion = new Vector3(0f, -alturaElemento * index - separacionVertical * index, 0f);

            GameObject usuarioPrefab = Instantiate(prefabDeUsuario, scrollViewContentTransform);
            usuarioPrefab.GetComponent<PrefabInfoPlayer>().establecerValoresTXT(usuario.Nickname, usuario.Score.ToString());
            usuarioPrefab.transform.localPosition = posicion;

            // Configurar elementos del prefab según los datos del usuario

            posicion.y -= alturaElemento + separacionVertical;

            index++;
        }
    }
}
