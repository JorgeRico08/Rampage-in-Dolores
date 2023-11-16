using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeart : MonoBehaviour
{

    public int totalHealth = 3;
    public RectTransform heartUI;

    //game over
    public RectTransform gameOverMenu;
    public GameObject hordes;
    public Transform OriginPoint;

    private int health;
    private float heartSize = 16f;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerCntroller _controller;

    public void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerCntroller>();
    }

    void Start()
    { 
        health = totalHealth;  
    }

    public void AddDamage(int amount)
    {
        health = health - amount;

        StartCoroutine("VisualFeedback");

        // Game over
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Daño" + health);
    }

    public void AddHealth(int amount)
    {
        health = health + amount;

        if (health > totalHealth)
        {
            health = totalHealth;
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Daño" + health);
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }

    private void OnEnable()
    {
        health = totalHealth;
    }

    private void OnDisable()
    {
        gameOverMenu.gameObject.SetActive(true);

        hordes.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;

        // Agregado
        _renderer.color = Color.white;
        health = 3;
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

        _controller.transform.position  =   new Vector2(OriginPoint.transform.position.x, OriginPoint.transform.position.y);


    }

}
