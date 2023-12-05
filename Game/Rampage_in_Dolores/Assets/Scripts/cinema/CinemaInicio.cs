using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemaInicio : MonoBehaviour
{
    // Referencia al panel 
    [SerializeField] private GameObject panelDialogo;

    // Referencia al texto del panel
    [SerializeField] private TMP_Text textoDialogo;
    // Arreglo de dialogos
    [SerializeField, TextArea(4, 6)] private string[] arrDialogos;

    // Referencia a la pantalla negra.
    [SerializeField] private GameObject panelPantallaNegra;

    // Referencia al peronaje (en este caso a Jacobo)
    [SerializeField] private GameObject personaje;

    // Nombre de la escena siguiente
    public string scene;

    TMP_Text textoPantallaNegra;

    // Variable para saber si ya comenzó a mostrarse los dialogos
    private bool isComenzoDialogos = false;

    private bool isVisiblePantalla = false;

    // Indica que linea de dialogo estamos mostrando
    private int iLineIndex = 0;

    public void Awake()
    {
        // Obtenemos el objeto TextMeshPro dentro del objeto pantalla.
        textoPantallaNegra = panelPantallaNegra.GetComponentInChildren<TMP_Text>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //textoPantallaNegra = panelPantallaNegra.GetComponentInChildren<TMP_Text>();
        comenzarDialogos();
    }

    // Update is called once per frame
    void Update()
    {
        // Si aun no se ha mostrado la pantalla negra al inicio de la cinematica.
        if (isVisiblePantalla == false)
        {
            // Se muestra la pantalla negra con el mensaje "Hace dos semanas..."
            //mostrarPantalla("Hace dos semanas...");
            // Se marca que se ha visualizado ya la pantalla negra
            isVisiblePantalla = true;
        }
        // Si ya se mostro la pantalla negra al inicio de la cinematica.
        else
        {
            // Si se ha presionado enter.
            if (Input.GetButtonDown("Submit"))
            {
                // Si aun no se a mostrado ningun dialogo.
                if (isComenzoDialogos == false)
                {
                    // Se oculta la pnatalla negra.
                    //ocultarPantalla();
                    // Se muestra el primer dialogo.
                    comenzarDialogos();
                }
                // Si ya se mostro el primer dialogo.
                else
                {

                    // Si se termino de mostrar el dialogo completo en el panel de dialogos
                    if (textoDialogo.text == arrDialogos[iLineIndex])
                    {
                        // Se sigue con el siguiente dialogo.
                        siguienteLineaDialogo();
                    }
                    else
                    {
                        // Se detiene la funcion que muestra letra por letra cada 0.02 segundos el dialogo
                        StopAllCoroutines();
                        // Se acompleta el dialogo.
                        textoDialogo.text = arrDialogos[iLineIndex];
                    }

                }
            }

        }

    }

    private void comenzarDialogos()
    {
        // Se marca que ya se ha mostrado el primer dialogo.
        isComenzoDialogos = true;
        // Se activa el panel para mostrar el dialogo (para que se pueda ver en el juego ya que permanece oculto).
        panelDialogo.SetActive(true);
        // Ejecutamos la funcion coroutine llamada mostrarLineaTexto (verla mas abajo en el codigo)
        StartCoroutine("mostarLineaTexto");
    }

    // Metodo para ir a la siguiente linea de dialogo
    private void siguienteLineaDialogo()
    {
        // sumamos 1 al indice, con el objetivo de ir al siguiente dialogo contenido en el arreglo arrDialogos
        iLineIndex++;
        // Verificamos si no es el ultimo elemento en el arreglo.
        if (iLineIndex < arrDialogos.Length)
        {
            // Cuando se llega al elemento 7 del arreglo, se debe mostrar de nuevo la pantalla negra (según el guion)
            if (iLineIndex == 5)
            {
                // Muestra la pantalla negra con el mensaje "Una hora después."
                //mostrarPantalla("Una hora después.");
                // Muestra el personaje Jacobo
                personaje.SetActive(true);
            panelPantallaNegra.SetActive(true);
                // Acompletamos el dialogo actual para que cuando se vuelva a dar enter, se sigua con el siguiente dialogo.
                textoDialogo.text = arrDialogos[iLineIndex];
            }
            else
            {
                // Se mantiene oculta la pantalla negra.
                ocultarPantalla();
                // Se mantiene visible el panel de dialogos.
                panelDialogo.SetActive(true);
                // Se muestra el dialogo.
                StartCoroutine("mostarLineaTexto");
            }


        }
        else
        {
            print("Siguiente escena");
            panelDialogo.SetActive(false);
            // TODO: Ir a la siguiente cinematica
            SceneManager.LoadScene("Nivel 1");
        }
    }

    // Funcion Coroutine mostrarLineaTexto
    private IEnumerator mostarLineaTexto()
    {
        // dejamos vacio el texto que se este mostrando actualmente.
        textoDialogo.text = string.Empty;
        // Recorremos cada letra del nuevo texto
        // Mostramos en cada 0.02 segundo cada letra del nuevo texto.
        foreach (var letra in arrDialogos[iLineIndex])
        {
            textoDialogo.text += letra;
            // Esperamos 0.02 segundos pára la siguiente letra.
            yield return new WaitForSeconds(0.02f);
        }
    }

    // Metodo para mostrar la pantalla negra.
    private void mostrarPantalla(string sMensaje)
    {
        panelDialogo.SetActive(false);
        panelPantallaNegra.SetActive(true);
        textoPantallaNegra.text = sMensaje;
    }

    // Metodo para ocultar la pantalla negra.
    private void ocultarPantalla()
    {
        panelPantallaNegra.SetActive(false);
    }

}
