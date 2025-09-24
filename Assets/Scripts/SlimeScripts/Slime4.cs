using UnityEngine;
using UnityEngine.AI;

public class Slime4 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition4;

    public bool AttackPlayer4;
    public bool SlimeIsHome4;
    public bool SlimeIsHit4;
    public bool SlimeIsAlive4 = true;

    public int slimeHealth4 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome4 = true;
        AttackPlayer4 = false;
        slimeHealth4 = 100;
        SlimeIsHit4 = false;
        SlimeIsAlive4 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth4 > 0)
        {
            if (player.PlayerInRange4 && GetDistancePlayer() < 5)
            {
                AttackPlayer4 = true;
            }

            else
            {
                AttackPlayer4 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome4 = true;
            }
            else
            {
                SlimeIsHome4 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange4 = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange4)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange4)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer4)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer4)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition4.position);
                    navemeshAgent.transform.LookAt(startPosition4);

                    if (player.PlayerInRange4)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome4)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive4 = false;
            Invoke("SlimeDeath", 2f);
        }


    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition4.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition4.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth4 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit4 = true;
        }
    }

    private void SlimeDeath()
    {
        gameObject.SetActive(false);
    }

    public enum SlimeState
    {
        IDLE,
        HOME,
        ATTACK,
        MOVE
    }
}


