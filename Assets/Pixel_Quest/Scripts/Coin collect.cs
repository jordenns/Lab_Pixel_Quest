using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public int coinsCollected = 0; // Counter for collected coins

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increment coin count
            coinsCollected++;
            Debug.Log("Coins Collected: " + coinsCollected);

            // Destroy the coin
            Destroy(other.gameObject);
        }
    }
}
