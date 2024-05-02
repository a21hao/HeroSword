using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHouse3 : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    private Animator animator;
    private bool contact = false;

    void Start()
    {
        gameObject = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            contact = true;
            IsOpening();
            EnterHome();
            //SceneManager.LoadScene("Game");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            contact = false;
            IsOpening(); ;
        }
    }

    private void IsOpening()
    {
        if (contact)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
        }
    }
        private void EnterHome()
    {
        SceneManager.LoadScene("House3");
    }
}
