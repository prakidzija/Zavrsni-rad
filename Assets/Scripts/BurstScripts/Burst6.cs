using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst6 : MonoBehaviour
{
    public Slime6 slime;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime.SlimeIsAlive6)
        {
            animator.SetBool("IsAlive", false);
        }

        else
        {
            animator.SetBool("IsAlive", true);
        }
    }
}
