using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private bool _isAttacking;
    private Animator _animator;
    // private AudioSource _audio;

    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
            // _audio.Play();
        }
        else 
        {
            _isAttacking = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking == true)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Big Bullet"))
            {
                collision.SendMessageUpwards("AddDamage");
            }
        }
    }
}
