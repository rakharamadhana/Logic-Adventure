using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LoadScene(1));
    }

    public void LoadNextScene()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        StartCoroutine(LoadScene(0));
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
