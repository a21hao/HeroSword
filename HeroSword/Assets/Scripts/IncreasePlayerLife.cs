using UnityEngine;

public class IncreasePlayerLife : MonoBehaviour
{
    public int healingAmount = 5;
    public PlayerLife playerLife;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.Heal(healingAmount); 
            }
            Destroy(gameObject);
        }
    }
}
