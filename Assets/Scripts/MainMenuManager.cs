using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject MenuCanvas, OptionsMenuCanvas, AboutMenuCanvas, SettingsMneuCanvas;
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public TMP_Text titleText;
    public bool isFadingIn = true;
    private int nextSceneToLoad;
    private Color initialColor;
    // Start is called before the first frame update

    public void Start()
    {
        initialColor = titleText.color;
    }

    private void Update()
    {
        if (isFadingIn)
        {
            FadingIn();
           
        }

        if (!isFadingIn)
        {
            FadingOut();
        }
    }

    public void FadingIn()
    {
        if (isFadingIn && titleText.alpha <1)
        {
            titleText.alpha = Mathf.MoveTowards(titleText.alpha, 1f, 0.2f * Time.deltaTime);
        }

        if (titleText.alpha == 1)
        {
            isFadingIn = false;
        }
    }

    public void FadingOut()
    {
        if (!isFadingIn)
        {
            titleText.alpha = Mathf.MoveTowards(titleText.alpha, 0f, 0.3f * Time.deltaTime);
        }

        if (titleText.alpha == 0)
        {
            isFadingIn = true;
        }
    }

    public void OpenAboutMenu()
    {
        MenuCanvas.gameObject.SetActive(false);
        AboutMenuCanvas.gameObject.SetActive(true);
    }

    public void OpenSettingsCanvas()
    {
        // TODO: additional settings menu
    }

    public void StartNewGame()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneToLoad);
    }



    public void OpenOptionsMenu()
    {
        MenuCanvas.gameObject.SetActive(false);
        OptionsMenuCanvas.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MenuCanvas.gameObject.SetActive(true);
        OptionsMenuCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit the game");
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
