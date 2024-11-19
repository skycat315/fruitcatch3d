using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Flag to indicate if the Home button is pressed
    private bool isHomeButtonDown = false;

    // Go back to the start screen when the Home button is pressed
    public void BackToHome()
    {
        SceneManager.LoadScene("StartScene");

        // Load the start scene when the Home button is pressed
        if (this.isHomeButtonDown)
        {
            SceneManager.LoadScene("StartScene");
        }
    }

    // Process when the Home button is pressed
    public void GetHomeButtonDown()
    {
        this.isHomeButtonDown = true;
    }

    // Process when the Home button is released
    public void GetHomeButtonUp()
    {
        this.isHomeButtonDown = false;
    }
}
