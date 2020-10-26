using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public GameObject trueAnswer;
    public GameObject falseAnswer;

    public GameObject AnswerA;
    public GameObject AnswerB;
    public GameObject AnswerC;

    private string choiceA;
    private string choiceB;
    private string choiceC;

    public string choiceIndex;

    [HideInInspector]
    public bool isAnswered = false;

    [SerializeField]
    private ScoreManager scoreManager = null;

    private int sceneIndex = 0;

    private void Start()    
    {
        InitializeAnswers();
        isAnswered = false;
    }

    void Update()
    {
        if ((sceneIndex < 10 || sceneIndex > 11) && isAnswered && Input.GetKeyDown(KeyCode.Mouse0))
        {
            sceneLoader.LoadNextScene();
        }
        else if ((sceneIndex > 9 || sceneIndex < 12) && isAnswered && Input.GetKeyDown(KeyCode.Mouse0))
        {
            sceneLoader.LoadNextSceneNoAnim();
        }
        
    }

    void InitializeAnswers()
    {
        if (AnswerA)
        {
            Button btnA = AnswerA.GetComponent<Button>();
            choiceA = AnswerA.GetComponentInChildren<TextMeshProUGUI>().text;
            btnA.onClick.AddListener(OnClickA);
        }

        if (AnswerB)
        {
            Button btnB = AnswerB.GetComponent<Button>();
            choiceB = AnswerB.GetComponentInChildren<TextMeshProUGUI>().text;
            btnB.onClick.AddListener(OnClickB);
        }

        if (AnswerC)
        {
            Button btnC = AnswerC.GetComponent<Button>();
            choiceC = AnswerC.GetComponentInChildren<TextMeshProUGUI>().text;
            btnC.onClick.AddListener(OnClickC);
        }
    }

    void OnClickA()
    {
        PlayerPrefs.SetString(choiceIndex, choiceA);
    }

    void OnClickB()
    {
        PlayerPrefs.SetString(choiceIndex, choiceB);
    }

    void OnClickC()
    {
        PlayerPrefs.SetString(choiceIndex, choiceC);
    }

    public void TrueAnswer()
    {
        FindObjectOfType<AudioManager>().Play("True SFX");
        StartCoroutine(scoreManager.AddScore(100));
        trueAnswer.SetActive(true);
        isAnswered = true;
    }

    public void FalseAnswer()
    {
        FindObjectOfType<AudioManager>().Play("False SFX");
        falseAnswer.SetActive(true);
        isAnswered = true;
    }
}
