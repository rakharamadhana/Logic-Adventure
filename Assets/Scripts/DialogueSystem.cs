using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    [System.Serializable]
    public class Sentence
    {
        [TextArea(3,5)]
        public string content;
        public bool isQuestion;
    }

    public Sentence[] sentences = new Sentence[0];

    private int index;
    public float typingSpeed;

    public GameObject answerContainer;

    public GameObject continueButton;
    public GameObject previousButton;
    public GameObject nextSceneButton;
    public Animator textDisplayAnim;

    void Start()
    {
        answerContainer.SetActive(false);
        StartCoroutine(Type());
    }

    void Update()
    {
        //Debug.Log(index);
        if (textDisplay.text == sentences[index].content && index != sentences.Length - 1) // Jika dialogue masih berjalan
        {
            if (index != 0) previousButton.SetActive(true);
            continueButton.SetActive(true);
        }
        else if (textDisplay.text == sentences[index].content && index == sentences.Length - 1 && sentences[index].isQuestion) // Jika dialogue selesai dan merupakan pertanyaan
        {
            previousButton.SetActive(true);
            answerContainer.SetActive(true);
            Debug.Log("Question Time");
        }
        else if (textDisplay.text == sentences[index].content && index == sentences.Length - 1) // Jika dialogue selesai dan ingin pindah scene berikutnya
        {
            nextSceneButton.SetActive(true);
        }

        
    }

    IEnumerator Type() // Dialogue Typing Animation
    {
        textDisplay.text = "";
        foreach(char letter in sentences[index].content.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        textDisplayAnim.SetTrigger("NextSentence");
        continueButton.SetActive(false);
        previousButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else { // If Dialogue Ended
            textDisplay.text = "";
            continueButton.SetActive(false);
            previousButton.SetActive(false);
        }
    }

    public void PreviousSentence()
    {
        textDisplayAnim.SetTrigger("NextSentence");
        continueButton.SetActive(false);
        previousButton.SetActive(false);
        answerContainer.SetActive(false);

        if (index > 0)
        {
            index--;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        { // If Dialogue Ended
            textDisplay.text = "";
            continueButton.SetActive(false);
            previousButton.SetActive(false);
            answerContainer.SetActive(false);
        }
    }
}
