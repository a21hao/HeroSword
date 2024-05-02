using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public int damage = 3;
    public Vector2 rightAttackOffset;
    [SerializeField] private Vector3 faceRigth = new Vector3(1, 0.9f, 0);
    [SerializeField] private Vector3 faceLeft = new Vector3(-1, 0.9f, 0);
    

    private void Start()
    { 
        rightAttackOffset = transform.position;
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
        PlayerPrefs.SetInt("PlayerDamage", damage); 
        PlayerPrefs.Save();
        if (newDamage > damage)
        {
            damage = newDamage;
            PlayerPrefs.SetInt("PlayerMaxDamage", damage); 
            PlayerPrefs.Save();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject != null)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && other.CompareTag("Enemy"))
            {
                enemy.Health -= DamageManager.Damage; ;
            }
        }
    }

    void IsFacingRigth(bool isFaceRigth)
    {
        if (isFaceRigth)
        {
            gameObject.transform.localPosition = faceRigth;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
}
