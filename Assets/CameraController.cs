using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Cat object
    private GameObject cat;

    // Distance between the cat and the camera
    private float difference;

    void Start()
    {
        // Get the cat object
        this.cat = GameObject.Find("cat");

        // Calculate the difference in position (z-coordinate) between the cat and the camera
        this.difference = cat.transform.position.z - this.transform.position.z;
    }

    void Update()
    {
        // Move the camera's position to match the cat's position
        this.transform.position = new Vector3(0, this.transform.position.y, this.cat.transform.position.z - difference);
    }
}
