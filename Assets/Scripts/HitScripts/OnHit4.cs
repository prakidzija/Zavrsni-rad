using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit4 : MonoBehaviour
{
    public Animator animator;

    public Slime4 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit4)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit4 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
