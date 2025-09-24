using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    public Animator animator;

    public Slime slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
