using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Flag to indicate if the Play button is pressed
    private bool isPlayButtonDown = false;

    // Start the game when the Play button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");

        // Load the game scene when the Play button is pressed
        if (this.isPlayButtonDown)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // Process when the Play button is pressed
    public void GetPlayButtonDown()
    {
        this.isPlayButtonDown = true;
    }

    // Process when the Play button is released
    public void GetPlayButtonUp()
    {
        this.isPlayButtonDown = false;
    }
}
