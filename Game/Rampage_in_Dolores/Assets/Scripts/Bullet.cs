using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public int damege = 1;
	// public float speed = 2f;
	// public Vector2 direction;

	// public float livingTime = 3f;
	// public Color initialColor = Color.white;
	// public Color finalColor;

	// private SpriteRenderer _renderer;
	// private Rigidbody2D _rigidbody;
	// private float _startingTime;

	// private bool _returning;
    // // Start is called before the first frame update

    // void Awake()
	// {
	// 	_renderer = GetComponent<SpriteRenderer>();
	// 	_rigidbody = GetComponent<Rigidbody2D>();
	// }

	// // Start is called before the first frame update
	// void Start()
    // {
	// 	//  Save initial time
	// 	_startingTime = Time.time;

	// 	// Destroy the bullet after some time
	// 	Destroy(gameObject, livingTime);
    // }

    // // Update is called once per frame
    // void Update()
    // {


	// 	// Change bullet's color over time
	// 	float _timeSinceStarted = Time.time - _startingTime;
	// 	float _percentageCompleted = _timeSinceStarted / livingTime;

	// 	_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    // }

	// private void FixedUpdate()
	// {
	// 	//  Move object
	// 	Vector2 movement = direction.normalized * speed;
	// 	_rigidbody.velocity = movement;
	// }

	// private void OnTriggerEnter2D(Collider2D collision)
	// {
	// 	if (_returning == false && collision.CompareTag("Player")) {

	// 		collision.SendMessageUpwards("AddDamage", damege);
	// 		Destroy(gameObject);
	// 		// Tell player to get hurt
	// 	}
	// 	if (_returning == true && collision.CompareTag("Enemy")) {
		
	// 		collision.SendMessageUpwards("AddDamage");
	// 		Destroy(gameObject);
	// 	}
	// }

	// public void AddDamage()
	// {
	// 	_returning = true;
	// 	direction = direction * -1f;
	// }

    // public float Speed;

    // public int damege = 1;

    // private Rigidbody2D Rigidbody2D;
    // private Vector3  Direction;

    // public Vector2 direction;

    // public float livingTime = 3f;
    // 	private float _startingTime;

    //     private bool _returning;

    // // Start is called before the first frame update
    // void Awake()
    // {
    //     Rigidbody2D = GetComponent<Rigidbody2D>();
    // }
    // void Start()
    // {
    //     _startingTime = Time.time;

	// 	// Destroy the bullet after some time
	// 	Destroy(gameObject, livingTime);
    // }

    // private void FixedUpdate()
    // {
    //     Rigidbody2D.velocity = Direction * Speed;
    // }

    // public void SetDirection(Vector3 direction)
    // {
    //     Direction = direction;
    // }


    // private void OnTriggerEnter2D(Collider2D collision)
	// {
	// 	// if (_returning == false && collision.CompareTag("Player")) {

	// 	// 	collision.SendMessageUpwards("AddDamage", damege);
	// 	// 	Destroy(gameObject);
	// 	// 	// Tell player to get hurt
	// 	// }
	// 	// if (_returning == true && collision.CompareTag("Enemy")) {
		
	// 	// 	collision.SendMessageUpwards("AddDamage");
	// 	// 	Destroy(gameObject);
	// 	// }
	// 	Enemy enemy = collision.GetComponent<Enemy>();
    //     PlayerController Player = collision.GetComponent<PlayerController>();

    //     if (enemy != null)
    //     {
	// 		// if(collision.CompareTag("Enemy")){
    //         	enemy.Hit();
	// 		// }
    //     }


    //     // if (Player != null)
    //     // {
    //     //     Player.Hit();
    //     // }
    //     Destroy(gameObject);
	// }

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
        DatosPlayer Datos_Player = DatosPlayer.DatosPlayerinstance;

        if (other.CompareTag("Player")) {
            // collision.SendMessageUpwards("AddDamage");
            Datos_Player.hurtPlayer();
			Destroy(gameObject);
		}
    }


}
