using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public string nextLevel = "Geo_Quest_Scene_2";
    private int coinCounter = 0;
    private int coinsInLevel= 0;
    public int playerHealth = 3;
    public int maxHealth = 3;
    public Transform RespawnPoint;
    public PlayerUiController _playerUIController;
    // Start is called before the first frame update

    private void Start()
    {
        coinsInLevel = GameObject.Find("Coins").transform.childCount;
        _playerUIController = GetComponent<PlayerUiController>();
        _playerUIController.StartUI();
        _playerUIController.UpdateHealth(playerHealth, maxHealth);

        _playerUIController.UpdateCoin(coinCounter + "/" + coinsInLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    playerHealth--;
                    _playerUIController.UpdateHealth(playerHealth, maxHealth);
                    if (playerHealth <= 0)
                    {
                        string thislevel = SceneManager.GetActiveScene().name;
                        SceneManager.LoadScene(thislevel);
                    }
                    else
                    {
                        transform.position = RespawnPoint.position;
                    }
                    break;
                }
            case "Coin":
                {
                    coinCounter++;
                    _playerUIController.UpdateCoin(coinCounter + "/" + coinsInLevel);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Health":
                {
                    if (playerHealth < 3)
                    {
                        playerHealth++;
                        _playerUIController.UpdateHealth(playerHealth,maxHealth);
                        Destroy(collision.gameObject);
                    }
                    break;
                }

            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Respawn":
                {
                    RespawnPoint.position = collision.transform.Find("Point").position;
                    break;
                }
        }
        
    }
}

