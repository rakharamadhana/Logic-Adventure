using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerSheet : MonoBehaviour
{
    public TextMeshProUGUI answerSheetContent;

    // Start is called before the first frame update
    void Start()
    {
        answerSheetContent.text = "";

        CheckAnswer(1, "A1", "90'");
        CheckAnswer(2, "A2", "90'");
        CheckAnswer(3, "A3", "90'");
        CheckAnswer(4, "A4", "90'");
        CheckAnswer(5, "A5", "90'");
    }

    void CheckAnswer(int index, string question, string key)
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
