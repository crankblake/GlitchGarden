using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    //GameObject gun;
    private void Start()
    {
        SetLaneSpawner();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
            // TODO change animation state to SHOOTING
        }
        else
        {
            Debug.Log("IDLE...");
            // TODO change animation state to IDLE
        }
    }

    private bool IsAttackerInLane()
    {
        //if myLaneSpawner child count less than or equal to 0 then return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
            return true;
    }

    public void Fire()
    {
        //gun = transform.Find("Gun").gameObject;
        var newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        //SetLaneSpawner();
    }
    public GameObject GetProjectile()
    {
        return projectile;
    }
}