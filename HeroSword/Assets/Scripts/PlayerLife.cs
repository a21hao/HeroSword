using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
    public int maxLife = 10;
    public int currentLife;
    public int Blink;
    public float time;

    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        currentLife = maxLife;
    }
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        Healthbar.HealthCurrent = currentLife;
        CineMachineShake.Instance.shakeCamera(1f, .1f);
        if(currentLife < 0)
        {
            currentLife = 0;
        }
        BlinkPlayer(Blink, time);
        if (currentLife <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        currentLife += amount;
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
        Healthbar.HealthCurrent = currentLife;
    }

        void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator DoBlinks(int numBlinksm, float seconds)
    {
        for (int i = 0; i < numBlinksm*2; i++) 
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }
}