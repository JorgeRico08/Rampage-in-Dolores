using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPrueba : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float bulletSpeed = 5f;
    public float followSpeed = 2f;
    public float shootInterval = 1f;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        // Mueve al enemigo hacia el jugador y haz que mire al jugador
        MoveTowardsPlayer();
        LookAtPlayer();
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Solo considera la dirección en el eje x hacia el jugador
        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0f).normalized;
        bulletRb.velocity = direction * bulletSpeed;
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
    }

    private void LookAtPlayer()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;
        // Calcula el ángulo de rotación hacia el jugador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Aplica la rotación al enemigo
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
