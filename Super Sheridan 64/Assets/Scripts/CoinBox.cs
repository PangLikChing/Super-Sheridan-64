using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] AudioSource boxBreakingSound;

    void OnCollisionEnter(Collision collision)
    {
        // If the player headbutt the coin box
        if (collision.gameObject.tag == "Player")
        {
            // Play the box breaking sound
            boxBreakingSound.Play();
            // Disable the box
            gameObject.SetActive(false);
        }
    }
}
