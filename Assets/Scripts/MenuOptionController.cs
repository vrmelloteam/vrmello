using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionController : MonoBehaviour {

    public Animator animator;
    public bool Hide;
    public void MenuShow()
    {
        Hide = !Hide;

        if (Hide)
        {
            animator.SetBool("Show", true);
            animator.SetBool("Hide", false);
        }
        else {
            animator.SetBool("Hide", true);
            animator.SetBool("Show", false);
        }

    }
   
}
