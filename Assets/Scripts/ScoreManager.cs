using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // From the inspector, drag & Drop the GameObject holding the Text component used to display the score
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private float addingSpeed = .05f;

    public bool adding = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("score", 0);
        }
    }

    void Update()
    {
        scoreText.text = "Skor: " + PlayerPrefs.GetInt("score").ToString();
        //Debug.Log("Adding Score: " + adding);
    }

    public IEnumerator AddScore(int scoresToAdd)
    {
        adding = true;

        int scores = PlayerPrefs.GetInt("score");

        while (scoresToAdd > 0)
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            scores += 10;
            scoresToAdd -= 10;
            PlayerPrefs.SetInt("score", scores);
            yield return new WaitForSeconds(addingSpeed);
        }

        adding = false;
    }

}
