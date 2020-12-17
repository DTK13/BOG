using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class FadingCanvas : MonoBehaviour
{
    public float fadeSpeed;
    public Image fadeCanvas;
    public Canvas storyCanvas;
    public TMP_Text chapterText;

    private void Start()
    {
        string chapterName = SceneManager.GetActiveScene().name;

        switch (chapterName)
        {
            case "Story1":
                chapterText.text = "Chapter 1";
                break;
            case "Story2":
                chapterText.text = "Chapter 2";
                break;
            case "Story3":
                chapterText.text = "Chapter 3";
                break;
            case "Story4":
                chapterText.text = "Chapter 4";
                break;
            case "Story5":
                chapterText.text = "Chapter 5";
                break;

        }
    }

    void Update()
    {
            fadeCanvas.color = new Color(fadeCanvas.color.r, fadeCanvas.color.g, fadeCanvas.color.b, Mathf.MoveTowards(fadeCanvas.color.a, 0, fadeSpeed *Time.deltaTime));
            chapterText.color = new Color(chapterText.color.r, chapterText.color.g, chapterText.color.b, Mathf.MoveTowards(chapterText.color.a, 0, fadeSpeed * Time.deltaTime));


        if (fadeCanvas.color.a <=.0f)
            {
                storyCanvas.gameObject.SetActive(true);
                fadeCanvas.gameObject.SetActive(false);
                
            }

    }
}
