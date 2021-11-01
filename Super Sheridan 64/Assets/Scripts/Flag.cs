using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic, victoryMusic;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Stop the background music
            backgroundMusic.Pause();
            // Play the victory Sound
            victoryMusic.Play();

            gameManager.isVictory = true;
        }
    }
}
