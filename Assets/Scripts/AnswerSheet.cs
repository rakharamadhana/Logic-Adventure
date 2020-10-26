using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerSheet : MonoBehaviour
{
    public Answer[] answers;

    public TextMeshProUGUI answerSheetContent;

    // Start is called before the first frame update
    void Start()    
    {
        answerSheetContent.text = "";

        foreach (Answer answer in answers)
        {
            CheckAnswer(answer.number, answer.answerCode, answer.answerKey);
        }
    }

    void CheckAnswer(string index, string question, string key)
    {
        if (PlayerPrefs.GetString(question) == key)
        {
            answerSheetContent.text += index + ". " + PlayerPrefs.GetString(question) + "\n";
        }
        else
        {
            answerSheetContent.text += index + ". " + PlayerPrefs.GetString(question) + " (X) \n";
        }
    }
}
