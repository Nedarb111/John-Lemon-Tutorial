using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shotspawn;
    //public bool Shooting;
    public float shotspeed = 10f;

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject projectile = Instantiate(projectilePrefab, shotspawn.transform.position, projectilePrefab.transform.rotation);
                Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
                projectileRB.velocity = transform.forward * shotspeed;
            }
    }
}
