using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit3 : MonoBehaviour
{
    public Animator animator;

    public Slime3 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit3)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit3 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
