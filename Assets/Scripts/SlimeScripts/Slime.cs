using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition;

    public bool AttackPlayer;
    public bool SlimeIsHome;
    public bool SlimeIsHit;
    public bool SlimeIsAlive = true;

    public int slimeHealth = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome = true;
        AttackPlayer = false;
        slimeHealth = 100;
        SlimeIsHit = false;
        SlimeIsAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth > 0)
        {
            if (player.PlayerInRange && GetDistancePlayer() < 5)
            {
                AttackPlayer = true;
            }

            else
            {
                AttackPlayer = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome = true;
            }
            else
            {
                SlimeIsHome = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition.position);
                    navemeshAgent.transform.LookAt(startPosition);

                    if (player.PlayerInRange)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive = false;
            Invoke("SlimeDeath", 2f);
        }


    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth -= 25;
            swing.SlimeHit = false;
            SlimeIsHit = true;
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


