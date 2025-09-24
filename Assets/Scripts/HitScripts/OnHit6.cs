using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit6 : MonoBehaviour
{
    public Animator animator;

    public Slime6 slime;
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.SlimeIsHit6)
        {
            animator.SetBool("IsHit", true);
            slime.SlimeIsHit6 = false;
        }

        else
        {
            animator.SetBool("IsHit", false);
        }
    }
}
