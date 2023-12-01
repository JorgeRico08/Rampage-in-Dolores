using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{
    public GameObject activationObject;
    public string enemyTag = "Enemy";  // Etiqueta de los enemigos

    void Update()
    {
        ActivateObject();
    }

    void ActivateObject()
    {
        // Encuentra todos los objetos con la etiqueta de enemigos
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Activa el objeto deseado solo si no hay enemigos en la escena
        if (enemies.Length == 0 && activationObject != null)
        {
            activationObject.SetActive(true);
        }
    }
}
