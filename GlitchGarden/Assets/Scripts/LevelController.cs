using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("END LEVEL NOW");
        }
    }
    // Update is called once per frame
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    void Update()
    {
        //Debug.Log(FindObjectsOfType<Attacker>().Length);
        /*Here's how I did the challenge
        if (FindObjectOfType<GameTimer>().GetTimerFinished())
        {
            if (FindObjectsOfType<Attacker>().Length == 0)
            {
                Debug.Log("END LEVEL NOW");
            }
        }*/
    }
}
