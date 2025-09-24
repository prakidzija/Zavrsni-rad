using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject player;

    public TMP_Text healthTXT;

    public bool PlayerInRange = false;
    public bool PlayerInRange1 = false;
    public bool PlayerInRange2 = false;
    public bool PlayerInRange3 = false;
    public bool PlayerInRange4 = false;
    public bool PlayerInRange5 = false;
    public bool PlayerInRange6 = false;

    public bool playerAlive = true;

    public int playerHealth = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackHealth();
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "SlimeZone")
        {
            PlayerInRange = true;
        }

        else if (collider.gameObject.tag == "SlimeZone1")
        {
            PlayerInRange1 = true;
        }


        else if (collider.gameObject.tag == "SlimeZone2")
        {
            PlayerInRange2 = true;
        }

        else if (collider.gameObject.tag == "SlimeZone3")
        {
            PlayerInRange3 = true;
        }

        else if (collider.gameObject.tag == "SlimeZone4")
        {
            PlayerInRange4 = true;
        }

        else if (collider.gameObject.tag == "SlimeZone5")
        {
            PlayerInRange5 = true;
        }

        else if (collider.gameObject.tag == "SlimeZone6")
        {
            PlayerInRange6 = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            playerHealth--;
        }

        //else if (collision.gameObject.CompareTag("Heal") && playerHealth < 5)
        //{
        //    playerHealth++;
        //}
    }

    private void TrackHealth()
    {
        healthTXT.text = playerHealth.ToString();

        if(playerHealth == 0)
        {
            playerAlive = false;
        }
    }
}
