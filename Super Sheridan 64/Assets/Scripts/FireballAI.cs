using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAI : MonoBehaviour
{
    const float movementSpeed = 120f;

    [SerializeField] bool closewise;

    GameManager gameManager;

    Transform bridge;

    void Start()
    {
        bridge = transform.parent.transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (closewise == true)
        {
            transform.RotateAround(bridge.position, bridge.right, -movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(bridge.position, bridge.right, movementSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.isGameOver = true;
        }
    }
}
