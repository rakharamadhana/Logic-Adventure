using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public DialogueSystem dialogue;

    public int nextSlideAfter;
    public Sprite nextImage;

    private Image sourceImage;

    // Start is called before the first frame update
    void Start()
    {
        sourceImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.index > nextSlideAfter) sourceImage.sprite = nextImage;
    }
}
