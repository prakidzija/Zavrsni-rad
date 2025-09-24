using UnityEngine;
using UnityEngine.AI;

public class Slime5 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition5;

    public bool AttackPlayer5;
    public bool SlimeIsHome5;
    public bool SlimeIsHit5;
    public bool SlimeIsAlive5 = true;

    public int slimeHealth5 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome5 = true;
        AttackPlayer5 = false;
        slimeHealth5 = 100;
        SlimeIsHit5 = false;
        SlimeIsAlive5 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth5 > 0)
        {
            if (player.PlayerInRange5 && GetDistancePlayer() < 5)
            {
                AttackPlayer5 = true;
            }

            else
            {
                AttackPlayer5 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome5 = true;
            }
            else
            {
                SlimeIsHome5 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange5 = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange5)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange5)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer5)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer5)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition5.position);
                    navemeshAgent.transform.LookAt(startPosition5);

                    if (player.PlayerInRange5)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome5)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive5 = false;
            Invoke("SlimeDeath", 2f);
        }

    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition5.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition5.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth5 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit5 = true;
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


