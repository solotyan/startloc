using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject menuPaused;

    public Slider slider;
    public GameObject loadingScreen;
    private int sceneToLoad;
    
    public void PlayGame()
    {
        sceneToLoad = 1;
        StartCoroutine(LoadingScreenOnFade());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        sceneToLoad = 0;
        StartCoroutine(LoadingScreenOnFade());
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 9f);
            slider.value = progress;
            yield return null;
        }
    }
}
