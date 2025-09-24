using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit5 : MonoBehaviour
{
    public Animator animator;

    public Slime5 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit5)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit5 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
