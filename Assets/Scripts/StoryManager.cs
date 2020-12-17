using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class StoryManager : MonoBehaviour
{
    public TMP_Text chapterName;
    public TextMeshProUGUI storyText;
    public GameObject continueButton;
    public Image chapterImage;
    private int index=0;
    [TextArea(10,15)]
    public string[] storySentences;
    public float typeSpeed;
    public class ChapterNames
    {
        internal const string Chapter1 = "The Return";
        internal const string Chapter2 = "Vengeance";
        internal const string Chapter3 = "Conquest";
        internal const string Chapter4 = "Unification";
        internal const string Chapter5 = "Rebirth";
    }

    public class StorySceneNames
    {
        internal const string Scene1 = "Story1";
        internal const string Scene2 = "Story2";
        internal const string Scene3 = "Story3";
        internal const string Scene4 = "Story4";
        internal const string Scene5 = "Story5";
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == StorySceneNames.Scene1)
        {
            chapterName.text = ChapterNames.Chapter1;
        }

        if (SceneManager.GetActiveScene().name == StorySceneNames.Scene2)
        {
            chapterName.text = ChapterNames.Chapter2;
        }
        if (SceneManager.GetActiveScene().name == StorySceneNames.Scene3)
        {
            chapterName.text = ChapterNames.Chapter3;
        }
        if (SceneManager.GetActiveScene().name == StorySceneNames.Scene4)
        {
            chapterName.text = ChapterNames.Chapter4;
        }
        if (SceneManager.GetActiveScene().name == StorySceneNames.Scene5)
        {
            chapterName.text = ChapterNames.Chapter5;
        }
    }
    void Start()
    {
        continueButton.SetActive(false);
        StartCoroutine(TypeSentence());
    }

    // Update is called once per frame
    void Update()
    {
        if (storyText.text == storySentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator TypeSentence()
    {
      foreach (char letter in storySentences[index].ToCharArray())
        {
            storyText.text += letter;
            if (letter.ToString()=="." || letter.ToString()==",")
            {
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(typeSpeed);

        }
 
    }

    public void ContinueDialog()
    {
        continueButton.SetActive(false);
        if (index < storySentences.Length - 1)
        {
            index++;
            storyText.text = "";
            StartCoroutine(TypeSentence());
        }
        else if (index == storySentences.Length -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            storyText.text = "";
            continueButton.SetActive(false);
        }

    }
}
