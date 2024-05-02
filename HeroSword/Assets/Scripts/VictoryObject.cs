using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryObject : MonoBehaviour
{
    public GameObject victory;
    private bool collisionOccurred = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            if (victory != null)
            {
                victory.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
