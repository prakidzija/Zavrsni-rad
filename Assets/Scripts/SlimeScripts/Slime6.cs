using UnityEngine;
using UnityEngine.AI;

public class Slime6 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    public NavMeshAgent navemeshAgent;

    public Player player;

    public SwordSwing swing;

    public float shootTimer = 2f;

    public Transform startPosition6;

    public bool AttackPlayer6;
    public bool SlimeIsHome6;
    public bool SlimeIsHit6;
    public bool SlimeIsAlive6 = true;

    public int slimeHealth6 = 100;

    SlimeState state;

    void Start()
    {
        navemeshAgent = GetComponent<NavMeshAgent>();
        navemeshAgent.isStopped = true;
        SlimeIsHome6 = true;
        AttackPlayer6 = false;
        slimeHealth6 = 100;
        SlimeIsHit6 = false;
        SlimeIsAlive6 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (slimeHealth6 > 0)
        {
            if (player.PlayerInRange6 && GetDistancePlayer() < 5)
            {
                AttackPlayer6 = true;
            }

            else
            {
                AttackPlayer6 = false;
            }

            if (GetDistanceStart() < 1)
            {
                SlimeIsHome6 = true;
            }
            else
            {
                SlimeIsHome6 = false;
            }

            if (GetDistancePlayerStart() > 20)
            {

            }
            switch (state)
            {
                case SlimeState.IDLE:
                    Debug.Log("IDLE");
                    navemeshAgent.isStopped = true;

                    if (player.PlayerInRange6)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.MOVE:
                    Debug.Log("MOVE");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(player.transform.position);
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!player.PlayerInRange6)
                    {
                        state = SlimeState.HOME;
                    }

                    else if (AttackPlayer6)
                    {
                        state = SlimeState.ATTACK;
                    }

                    break;

                case SlimeState.ATTACK:
                    Debug.Log("ATTACK");
                    navemeshAgent.isStopped = true;
                    navemeshAgent.transform.LookAt(player.transform.position);

                    if (!AttackPlayer6)
                    {
                        state = SlimeState.MOVE;
                    }

                    break;

                case SlimeState.HOME:
                    Debug.Log("HOME");
                    navemeshAgent.isStopped = false;
                    navemeshAgent.SetDestination(startPosition6.position);
                    navemeshAgent.transform.LookAt(startPosition6);

                    if (player.PlayerInRange6)
                    {
                        state = SlimeState.MOVE;
                    }

                    else if (SlimeIsHome6)
                    {
                        state = SlimeState.IDLE;
                    }

                    break;

            }
        }

        else
        {
            SlimeIsAlive6 = false;
            Invoke("SlimeDeath", 2f);
        }

    }


    public float GetDistanceStart()
    {
        float distance = Vector3.Distance(startPosition6.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, navemeshAgent.transform.position);
        return distance;
    }

    public float GetDistancePlayerStart()
    {
        float distance = Vector3.Distance(player.transform.position, startPosition6.position);
        return distance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword") && swing.SlimeHit)
        {
            slimeHealth6 -= 25;
            swing.SlimeHit = false;
            SlimeIsHit6 = true;
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


