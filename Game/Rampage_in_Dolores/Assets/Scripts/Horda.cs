using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int numberOfEnemies = 10; 
    public float spawnInterval = 4f; 
    public GameObject activationObject;

    private void Start()
    {
        // Iniciar el ciclo de generación
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Instanciar un nuevo enemigo usando el prefab y la posición actual del spawner
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Esperar el intervalo de tiempo antes de generar el siguiente enemigo
            yield return new WaitForSeconds(spawnInterval);
        }

        // Llamada a la función que activa el objeto cuando se destruyen todos los enemigos
        ActivateObject();
    }

    void ActivateObject()
    {
        // Activa el objeto deseado cuando se destruyen todos los enemigos
        if (activationObject != null)
        {
            activationObject.SetActive(true);
        }
    }
}
