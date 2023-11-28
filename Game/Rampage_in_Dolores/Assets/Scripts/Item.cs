using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public int healRestoration = 1;

	// [SerializeField] GameObject lightingParticles;
	// [SerializeField] GameObject burstParticles;

	private SpriteRenderer _rederer;
	private Collider2D _collider;
	// private AudioSource _audio;

	private void Awake()
	{
		_rederer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<Collider2D>();
		// _audio = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        DatosPlayer Datos_Player = DatosPlayer.DatosPlayerinstance;
		if (collision.CompareTag("Player")) {

            Datos_Player.AddHealth(healRestoration);

			_rederer.enabled = false;
			// lightingParticles.SetActive(false);
			// burstParticles.SetActive(true);
			// _audio.Play();
			Destroy(gameObject, 2f);
		}
	}
}
