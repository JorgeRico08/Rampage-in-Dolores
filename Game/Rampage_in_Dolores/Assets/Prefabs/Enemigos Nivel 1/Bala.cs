using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public int daño;
    public float tiempoDeVida = 3f;

    void Start()
    {
        Invoke("DestruirDespuesDeTiempo", tiempoDeVida);
    }
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DatosPlayer Datos_Player = DatosPlayer.DatosPlayerinstance;

        if (collision.CompareTag("Player"))
        {
            // collision.SendMessageUpwards("AddDamage");
            Datos_Player.hurtPlayer();
            Datos_Player.restarPuntos(10);
            Destroy(gameObject);
        }
    }

    private void DestruirDespuesDeTiempo()
    {
        // Destruye la bala después de tiempoDeVida segundos
        Destroy(gameObject);
    }
}
