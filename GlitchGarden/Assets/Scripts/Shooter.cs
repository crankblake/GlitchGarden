using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    //GameObject gun;

    public void Fire()
    {
        //gun = transform.Find("Gun").gameObject;
        var newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
    public GameObject GetProjectile()
    {
        return projectile;
    }
}