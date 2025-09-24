using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit1 : MonoBehaviour
{
    public Animator animator;

    public Slime1 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit1)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit1 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
