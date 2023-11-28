using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_player : MonoBehaviour
{
    public float Speed;
    // public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
	public float livingTime = 0.50f;	

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

        
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
        Enemy enemy = other.GetComponent<Enemy>();
    	// PlayerController Player = other.GetComponent<PlayerController>();
        // if (enemy != null)
        // {
        //     enemy.Hit();
        // }
        // if (enemy != null)
        // {
        // }

            if (other.CompareTag("Enemy")) {
			// collision.SendMessageUpwards("AddDamage");
            enemy.Hit();
			Destroy(gameObject);
		    }
    }
}
