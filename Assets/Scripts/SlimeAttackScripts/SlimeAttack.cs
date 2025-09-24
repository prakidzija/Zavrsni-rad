using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    public Slime slime;

    [SerializeField] private float shootTimer = 2f;
    public float projectileSpeed;

    public Vector3 vect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slime.AttackPlayer)
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
        myProjectile.tag = "Attack";
        Rigidbody rb = myProjectile.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * projectileSpeed);
        //Destroy(projectile);
    }



}
