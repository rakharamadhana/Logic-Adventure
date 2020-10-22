using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public GameObject trueAnswer;
    public GameObject falseAnswer;   

    [HideInInspector]
    public bool isAnswered = false;

    [SerializeField]
    private ScoreManager scoreManager;

    void Update()
    {
        if (isAnswered && Input.GetKeyDown(KeyCode.Mouse0))
        {
            sceneLoader.LoadNextScene();
        }
        
    }

    public void TrueAnswer()
    {
        Debug.Log("True");
        FindObjectOfType<AudioManager>().Play("True SFX");
        StartCoroutine(scoreManager.AddScore(100));
        trueAnswer.SetActive(true);
        isAnswered = true;
    }

    public void FalseAnswer()
    {
        Debug.Log("False");
        FindObjectOfType<AudioManager>().Play("False SFX");
        falseAnswer.SetActive(true);
        isAnswered = true;
    }
}
