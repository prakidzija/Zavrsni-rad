using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeAttack2 : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    public Slime2 slime;

    [SerializeField] private float shootTimer = 2f;
    public float projectileSpeed;

    public Vector3 vect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slime.AttackPlayer2)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = 2f;
            }
        }
    }

    public void Shoot()
    {
        GameObject myProjectile = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        Rigidbody rb = myProjectile.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * projectileSpeed);
        //Destroy(projectile);
    }



}
