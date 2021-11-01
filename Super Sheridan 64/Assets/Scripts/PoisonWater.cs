using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWater : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.isGameOver = true;
        }
    }
}
