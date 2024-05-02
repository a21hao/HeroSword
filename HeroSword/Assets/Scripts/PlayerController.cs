using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    public float moveSpeed = 150f;
    public float maxspeed = 8f;
    public float idleFriction = 0.9f;
    public SwordAttack swordAttack;
    public AudioSource audioSource;
    public AudioClip swordAttackSound;

    Vector2 moveInput;
    Rigidbody2D playerRb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    SpriteRenderer spriteRenderer;
    Collider2D swordCollider;
    bool canMove = true;
    bool isMoving = false;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordAttack.GetComponent<Collider2D>();
        int savedDamage = PlayerPrefs.GetInt("PlayerDamage", 1); 
        int savedMaxDamage = PlayerPrefs.GetInt("PlayerMaxDamage", 1); 

        int maxDamage = Mathf.Max(savedDamage, savedMaxDamage);
        swordAttack.SetDamage(maxDamage);
    }


    private void FixedUpdate()
    {
        if (canMove == true && moveInput != Vector2.zero)
        {
            playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxspeed);

            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRigth", true);
            }
            else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRigth", false );
            }
            IsMoving = true;
        }
        else
        {
            playerRb.velocity = Vector2.Lerp(playerRb.velocity, Vector2.zero, idleFriction);

            IsMoving = false;
        }
    }

    void OnMove ( InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire()
    {
        
        animator.SetTrigger("swordAttack");
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void SwordAttack()
    {

        //sfx.PlaySound(slashSFX);
        //LockMovement();
        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }

    public void LockMovement() 
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}