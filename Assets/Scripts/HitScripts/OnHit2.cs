using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit2 : MonoBehaviour
{
    public Animator animator;

    public Slime2 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit2)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit2 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
