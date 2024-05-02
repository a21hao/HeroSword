using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetDamage : MonoBehaviour
{
    public int newDamage = 5;
    public GameObject activateObject;
    public GameObject dialog;
    public TextMeshProUGUI dialogBoxText;
    [SerializeField] private float textDisplayTime = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();

            if (playerLife != null)
            {
                DamageManager.Damage = newDamage; // Modificar el valor de Damage en DamageManager
            }

            if (activateObject != null)
            {
                activateObject.SetActive(true);
            }

            if (dialog != null)
            {
                dialog.SetActive(true);
            }

            StartCoroutine(DisplayTextAndDestroy());
        }
    }

    private IEnumerator DisplayTextAndDestroy()
    {
        if (dialogBoxText != null)
        {
            dialogBoxText.gameObject.SetActive(true);

            if (dialog != null)
            {
                dialog.SetActive(true);
            }

            yield return new WaitForSeconds(textDisplayTime);

            dialogBoxText.gameObject.SetActive(false);

            if (dialog != null)
            {
                dialog.SetActive(false);
            }
        }
        Destroy(gameObject);
    }
}
