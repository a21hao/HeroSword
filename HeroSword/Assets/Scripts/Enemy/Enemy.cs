using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private Animator animator;
    Rigidbody2D rb;
    public float flashTime = 0.1f;
    public float _health = 1f;
    private SpriteRenderer sr; //change Color
    private Color originalColor;
    private PlayerLife playerLife;
    public GameObject dropItem;
    public GameObject floatPoint;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }


    public void Update()
    {

        if (_health <= 0)
        {
            animator.SetTrigger("Defeated");
            //Destroy(gameObject
        }
    }

    public virtual float Health
    {
        set
        {
            _health = value;
            GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
            gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
            if (value > 0)
            {
                animator.SetTrigger("Hit");
                FlashColor(flashTime);

            }

        }
        get
        {
            return _health;
        }
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
        Instantiate(dropItem, transform.position, Quaternion.identity);
    }

    private void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    private void ResetColor()
    {
        sr.color = originalColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
        }
    }
}
