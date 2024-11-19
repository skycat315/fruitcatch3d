using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCatController : MonoBehaviour
{
    // Component for animation
    private Animator homeCatAnimator;
    void Start()
    {
        // Get Animator component
        this.homeCatAnimator = GetComponent<Animator>();

        // Start walking animation
        GetComponent<Animator>().Play("Walk");
    }

    void Update()
    {
        // No actions in Update for now
    }
}
