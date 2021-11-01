using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        // Quit the game
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
