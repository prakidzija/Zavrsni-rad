using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    public Slime slime;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime.SlimeIsAlive)
        {
            animator.SetBool("IsAlive", false);
        }

        else
        {
            animator.SetBool("IsAlive", true);
        }
    }
}
