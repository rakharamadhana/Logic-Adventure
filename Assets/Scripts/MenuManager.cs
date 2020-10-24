using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    public GameObject MainMenuContainer;
    public GameObject InfoContainer;

    public float transitionTime = 1f;

    public void MainMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        MainMenuContainer.SetActive(true);
        InfoContainer.SetActive(false);
    }

    public void InfoButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");        
        InfoContainer.SetActive(true);
        MainMenuContainer.SetActive(false);
    }
}
