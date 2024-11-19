using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlGUI : MonoBehaviour {

    public Animator animator;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 160, 20, 140, 40), "Walk"))
        {
            animator.Play("Walk");
        }
        if (GUI.Button(new Rect(Screen.width - 160, 60, 140, 40), "Run"))
        {
            animator.Play("Run");
        }
        if (GUI.Button(new Rect(Screen.width - 160, 100, 140, 40), "Jump"))
        {
            animator.Play("Jump");
        }
    }
}
