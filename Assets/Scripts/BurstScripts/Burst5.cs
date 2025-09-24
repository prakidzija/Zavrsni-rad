using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst5 : MonoBehaviour
{
    public Slime5 slime;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime.SlimeIsAlive5)
        {
            animator.SetBool("IsAlive", false);
        }

        else
        {
            animator.SetBool("IsAlive", true);
        }
    }
}
