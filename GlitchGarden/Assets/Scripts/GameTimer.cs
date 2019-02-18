using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    bool timerFinished;
    bool triggeredLevelFinished = false;
    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            Debug.Log("level timer has expired");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
    public bool GetTimerFinished()
    {
        return timerFinished;
    }
}
