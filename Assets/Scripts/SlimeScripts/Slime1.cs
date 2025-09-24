using UnityEngine;
using UnityEngine.AI;

public class Slime1 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition1;

    public bool AttackPlayer1;
    public bool SlimeIsHome1;
    public bool SlimeIsHit1;
    public bool SlimeIsAlive1 = true;

    public int slimeHealth1 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome1 = true;
        AttackPlayer1 = false;
        slimeHealth1 = 100;
        SlimeIsHit1 = false;
        SlimeIsAlive1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth1 > 0)
        {
            if (player.PlayerInRange1 && GetDistancePlayer() < 5)
            {
                AttackPlayer1 = true;
            }

            else
            {
                AttackPlayer1 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome1 = true;
            }
            else
            {
                SlimeIsHome1 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange1 = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange1)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange1)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer1)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer1)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition1.position);
                    navemeshAgent.transform.LookAt(startPosition1);

                    if (player.PlayerInRange1)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome1)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive1 = false;
            Invoke("SlimeDeath", 2f);
        }


    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition1.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition1.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth1 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit1 = true;
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


