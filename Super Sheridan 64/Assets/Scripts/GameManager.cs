using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false, isVictory = false;

    public int coins = 0, score = 0;

    bool isDeathPlayed = false, isVictoryPlayed = false;

    [SerializeField] Animation cameraAnimation;

    [SerializeField] GameObject playerCamera, player, gameOverUI;

    [SerializeField] TMP_Text coinNumberText, gameoverText, scoreNumberText;

    void Awake()
    {
        // Initialize
        coins = 0;
        score = 0;
        coinNumberText.text = "" + coins;
        scoreNumberText.text = "" + score;
        // Make the mouse pointer invisible
        Cursor.visible = false;
        // Lock the mouse pointer within the game area
        Cursor.lockState = CursorLockMode.Locked;
        // Reset death
        isGameOver = false;
        isDeathPlayed = false;
        // Reset Win
        isVictory = false;
        isVictoryPlayed = false;
    }

    void Start()
    {
        cameraAnimation.Play();
    }

    void FixedUpdate()
    {
        // Playing
        if (playerCamera.GetComponent<MouseLook>().animationPlayed && isVictory == false && isGameOver == false)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }

        if (isVictory == true)
        {
            // Dislay Victory UI
            if (isVictoryPlayed == false)
            {
                // Display Game Over UI
                gameOverUI.SetActive(true);
                gameoverText.text = "You Win";
                // Disable player control
                Debug.Log("i am here");
                playerCamera.GetComponent<MouseLook>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody>().isKinematic = true;
                // Make the mouse cursor visible
                Cursor.visible = true;
                // Unlock the mouse cursor
                Cursor.lockState = CursorLockMode.None;
                // Tell the game manager that the victory is played
                isVictoryPlayed = true;
            }
        }
        else if (isGameOver == true)
        {
            if (isDeathPlayed == false)
            {
                // Display Game Over UI
                gameOverUI.SetActive(true);
                // Stop Background Music
                playerCamera.GetComponent<AudioSource>().Pause();
                // Play death sound
                player.GetComponent<AudioSource>().Play();
                // Disable player control
                playerCamera.GetComponent<MouseLook>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody>().isKinematic = true;
                // Make the mouse cursor visible
                Cursor.visible = true;
                // Unlock the mouse cursor
                Cursor.lockState = CursorLockMode.None;
                // Tell the game manager that the death is played
                isDeathPlayed = true;
            }
        }
    }

    public void UpdateCoins()
    {
        // Change the number on coin number text
        coinNumberText.text = "" + coins;
    }

    public void UpdateScore()
    {
        // Calculate and change the number on score number text
        scoreNumberText.text = "" + (score + (coins / 10 * 50));
    }
}
