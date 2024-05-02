using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private float delayTime;

    public GameObject sword;
    private Animator chestAnimator;
    private bool canOpen;
    private bool isOpened;

    void Start()
    {
        chestAnimator = GetComponent<Animator>();
        isOpened = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(canOpen && !isOpened)
            {
                chestAnimator.SetTrigger("Open");
                isOpened = true;
                Invoke("GenItem", delayTime);
                sword.SetActive(true);
            }
        }
    }
    void GenItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    void OnInteract()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }
}
