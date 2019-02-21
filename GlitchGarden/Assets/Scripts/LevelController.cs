using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int waitToLoadWin = 5;
    [SerializeField] int waitToLoadLose = 3;
    //[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    bool alreadyEnding = false;

    private void Start()
    {
        if (winLabel != null)
        {
            winLabel.SetActive(false);
        }
        if (loseLabel != null)
        {
            loseLabel.SetActive(false);
        }

        /*
        if (gameObject.tag == "Block")
        {
            GetComponent<Collider2D>().enabled = false;
        }*/
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished && !alreadyEnding)
        {
            alreadyEnding = true;
            //Debug.Log("END LEVEL NOW");
            //winLabel.SetActive(true);
            //FindObjectOfType<LevelLoader>().StartCoroutine("HandleWinCondition");
            StartCoroutine(HandleWinCondition());
        }
    }
    public void PlayerHealthIsZero()
    {
        //FindObjectOfType<DefenderSpawner>().gameObject.SetActive(false);
        //var buttons = FindObjectsOfType<DefenderButton>();
        /*
        if (gameObject.tag == "Block")
        {
            GetComponent<Collider2D>().enabled = true;
        }*/
        /*foreach (DefenderButton button in buttons)
        {
            button.gameObject.SetActive(false);
        }*/
        StartCoroutine(HandleLoseCondition());
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoadWin);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public IEnumerator HandleLoseCondition()
    {
        //GetComponent<AudioSource>().Play();
       yield return new WaitForSeconds(waitToLoadLose);
        loseLabel.SetActive(true);
        Time.timeScale = 0;
        //gameSpeed = 0f;
        //FindObjectOfType<LevelLoader>().LoadNextScene();
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
        //Time.timeScale = gameSpeed;
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
