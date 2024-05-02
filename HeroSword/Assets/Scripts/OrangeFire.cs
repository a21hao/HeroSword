using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFire : MonoBehaviour
{
    public Animator animator;
    public int damage = 1;
    public float damageInterval = 1.0f; 
    private bool isDamaging = false;
    private PlayerLife playerLife;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && !isDamaging)
        {
            playerLife = collision.gameObject.GetComponent<PlayerLife>();
            StartCoroutine(DealContinuousDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != null && playerLife != null)
        {
            StopCoroutine(DealContinuousDamage());
            playerLife = null;
            isDamaging = false;
        }
    }

    private IEnumerator DealContinuousDamage()
    {
        isDamaging = true;

        while (playerLife != null)
        {
            playerLife.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }

        isDamaging = false;
    }
}
