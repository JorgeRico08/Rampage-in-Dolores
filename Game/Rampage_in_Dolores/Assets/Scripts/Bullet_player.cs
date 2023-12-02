using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_player : MonoBehaviour
{
    public float Speed;
    // public AudioClip Sound;
    DatosPlayer datosPlayer;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
	public float livingTime = 0.50f;	

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

        datosPlayer = DatosPlayer.DatosPlayerinstance;
        Destroy(gameObject, livingTime);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DisparoEnemigo enemy = other.GetComponent<DisparoEnemigo>();

        if (other.CompareTag("Enemy")) {
			// collision.SendMessageUpwards("AddDamage");
            if (datosPlayer != null)
            {
                datosPlayer.sumarPuntos(20);
            }

            enemy.Hit();
            Destroy(gameObject);
		    }
    }
}
