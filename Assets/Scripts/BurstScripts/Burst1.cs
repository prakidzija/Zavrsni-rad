using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst1 : MonoBehaviour
{
    public Slime1 slime;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime.SlimeIsAlive1)
        {
            animator.SetBool("IsAlive", false);
        }

        else
        {
            animator.SetBool("IsAlive", true);
        }
    }
}
