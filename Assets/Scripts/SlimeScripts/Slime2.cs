using UnityEngine;
using UnityEngine.AI;

public class Slime2 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition2;

    public bool AttackPlayer2;
    public bool SlimeIsHome2;
    public bool SlimeIsHit2;
    public bool SlimeIsAlive2 = true;

    public int slimeHealth2 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome2 = true;
        AttackPlayer2 = false;
        slimeHealth2 = 100;
        SlimeIsHit2 = false;
        SlimeIsAlive2 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth2 > 0)
        {
            if (player.PlayerInRange2 && GetDistancePlayer() < 5)
            {
                AttackPlayer2 = true;
            }

            else
            {
                AttackPlayer2 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome2 = true;
            }
            else
            {
                SlimeIsHome2 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange2 = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange2)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange2)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer2)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer2)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition2.position);
                    navemeshAgent.transform.LookAt(startPosition2);

                    if (player.PlayerInRange2)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome2)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive2 = false;
            Invoke("SlimeDeath", 2f);
        }


    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition2.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition2.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth2 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit2 = true;
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


