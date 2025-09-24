using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SwordSwing : MonoBehaviour
{
    public Animator animator;

    public Player player;

    public bool SlimeHit = false;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAttacking", true);
            SlimeHit = true;
        }

        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
