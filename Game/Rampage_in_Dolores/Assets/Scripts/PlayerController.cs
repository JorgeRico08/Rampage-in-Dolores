using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed = 2.5f;
    public float jumpForce;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private float horizontalInput;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    private bool Grounded;

    private Vector2 _movement;
    private bool _isGrounded;
    private float LastShoot;

    private bool _isAttacking;

    private Transform _firePoint;
    private SpriteRenderer _renderer;
    // private int Health = 10;


    //private int totalHealth = 10;
    //private int health;
    //public RectTransform heartUI;
    //private float heartSize = 16f;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        //health = totalHealth;
    
    }

    private void Update()
    {
        // Movimiento
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontalInput > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("run", horizontalInput != 0.0f);
        // Debug.Log(horizontalInput != 0.0f);

        // Detectar Suelo
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        // if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        // {
        //     Grounded = true;
        // }
        // else Grounded = false;

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Debug.Log(_isGrounded);
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded == true)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        // Disparar
        if (Input.GetButtonDown("Fire1") && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
            Animator.SetTrigger("Shoot");
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontalInput * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
        Animator.SetTrigger("jump");
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet_player>().SetDirection(direction);

    }

    //public void Hit()
    //{
    //    health = health - 1;
    //    // Debug.Log(totalHealth);
    //    StartCoroutine("VisualFeedback");
    //    if (health <= 0)
    //    {
    //        gameObject.SetActive(false);
    //    } 
    //    heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    //    Debug.Log("Daño" + health);
    //}

    //public void AddHealth(int amount)
    //{
    //    health = health + amount;

    //    if (health > totalHealth)
    //    {
    //        health = totalHealth;
    //    }
    //    heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    //    Debug.Log("Mi vida " + health);
    
    //}

    //private IEnumerator VisualFeedback()
    //{
    //    _renderer.color = Color.red;

    //    yield return new WaitForSeconds(0.1f);

    //    _renderer.color = Color.white;
    //}
    // void Awake()
    // {
    //     _rigidbody = GetComponent<Rigidbody2D>();
    //     _animator = GetComponent<Animator>();
    //     _firePoint = transform.Find("FirePoint");
    // }
    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //         float horizontalInput = Input.GetAxisRaw("Horizontal");
    //         _movement = new Vector2(horizontalInput, 0f);

    //         if (horizontalInput < 0f && _facingRight == true)
    //         {
    //             Flip();

    //         }
    //         else if (horizontalInput > 0f && _facingRight == false)
    //         {
    //             Flip();
    //         }

    //     _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    //     // Debug.Log(_isGrounded);
    //     if (Input.GetKeyDown(KeyCode.W) && _isGrounded == true)
    //     {
    //         _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //     }

    //     if (Input.GetButtonDown("Fire1") && Time.time > LastShoot + 0.25f)
    //     {
    //         Shoot();
    //         LastShoot = Time.time;
    //         _animator.SetTrigger("Shoot");
    //     }

    // }

    // private void FixedUpdate()
    // {
    //         float horizontalVelocity = _movement.normalized.x * speed;
    //         _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    // }

    // void LateUpdate()
    // {
    //     _animator.SetBool("run", _movement == Vector2.zero);
    // }

    // private void Shoot()
    // {
    //     Vector3 direction;
    //     // if (transform.localScale.x == 1.0f) 
    //     // {
    //     // direction = Vector3.right;
    //     // }
    //     // else
    //     // {
    //     // direction = Vector3.left;
    //     // }

    //     GameObject bullet = Instantiate(BulletPrefab, _firePoint.position, Quaternion.identity);
    //     bullet.GetComponent<Bullet>().SetDirection(_firePoint.position);
    // }

    //     private void Flip()
    // {
    //     _facingRight = !_facingRight;
    //     float localScaleX = transform.localScale.x;
    //     localScaleX = localScaleX * -1f;
    //     transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    // }
    // public void Hit()
    // {
    //     Health --;
    //     if (Health == 0) Destroy(gameObject);
    // }
}
