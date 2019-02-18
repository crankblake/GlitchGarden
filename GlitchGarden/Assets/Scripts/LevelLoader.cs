using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int delayInSeconds = 3;
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
        yield return new WaitForSeconds(delayInSeconds);
        //SceneManager.LoadScene("StartScreen");
        LoadNextScene();
    }
    public IEnumerator WaitForTimeLoss()
    {
        yield return new WaitForSeconds(delayInSeconds);
        //SceneManager.LoadScene("StartScreen");
        LoadYouLose();
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }
    public void LoadYouLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
