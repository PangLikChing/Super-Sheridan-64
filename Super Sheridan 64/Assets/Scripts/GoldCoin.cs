using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinSound;
    GameManager gameManager;

    void Start()
    {
        // Initialize
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Play the coin pickup sound
            coinSound.Play();
            // Increase the number of coins
            gameManager.coins++;
            // Increase the number of score
            gameManager.score += 10;
            // Call the update functions for both coins and score in Game Manager
            gameManager.UpdateCoins();
            gameManager.UpdateScore();
            // Disable the coin
            gameObject.SetActive(false);
        }
    }
}
