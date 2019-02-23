using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int lossDelayInSeconds = 3;
    [SerializeField] int winDelayInSeconds = 5;
    //[SerializeField] AudioClip finishedLevelSFX;
    //[SerializeField] [Range(0, 1)] float clipVolume = .5f;
    int currentSceneIndex;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(lossDelayInSeconds);
        SceneManager.LoadScene("StartScreen");
        //LoadNextScene();
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void StartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }
    public void OptionsScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("OptionsScreen");
    }
    /*
    public IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(finishedLevelSFX, Camera.main.transform.position, clipVolume);
        yield return new WaitForSeconds(winDelayInSeconds);
        Debug.Log("Load next scene plox");
        LoadNextScene();
    }*/
}
