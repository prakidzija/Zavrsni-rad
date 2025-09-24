using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Player player;

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetDistanceDoor() < 2)
        {

        }
    }

    private float GetDistanceDoor()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        return distance;
    }
}
