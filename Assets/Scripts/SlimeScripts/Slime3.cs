using UnityEngine;
using UnityEngine.AI;

public class Slime3 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition3;

    public bool AttackPlayer3;
    public bool SlimeIsHome3;
    public bool SlimeIsHit3;
    public bool SlimeIsAlive3 = true;

    public int slimeHealth3 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome3 = true;
        AttackPlayer3 = false;
        slimeHealth3 = 100;
        SlimeIsHit3 = false;
        SlimeIsAlive3 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth3 > 0)
        {
            if (player.PlayerInRange3 && GetDistancePlayer() < 5)
            {
                AttackPlayer3 = true;
            }

            else
            {
                AttackPlayer3 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome3 = true;
            }
            else
            {
                SlimeIsHome3 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {
                player.PlayerInRange3 = false;
            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange3)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange3)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer3)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer3)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition3.position);
                    navemeshAgent.transform.LookAt(startPosition3);

                    if (player.PlayerInRange3)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome3)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive3 = false;
            Invoke("SlimeDeath", 2f);
        }


    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition3.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition3.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth3 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit3 = true;
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


