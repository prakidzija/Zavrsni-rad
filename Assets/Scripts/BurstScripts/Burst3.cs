using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst3 : MonoBehaviour
{
    public Slime3 slime;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!slime.SlimeIsAlive3)
        {
            animator.SetBool("IsAlive", false);
        }

        else
        {
            animator.SetBool("IsAlive", true);
        }
    }
}
