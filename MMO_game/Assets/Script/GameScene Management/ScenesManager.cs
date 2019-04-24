using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    static GameObject loaderPanel;
    static Slider sceneLoader;
    static Text progressText;
    public static ScenesManager scenesManager;
    bool gameStarted = false;
    void Start()
    {
        if (!gameStarted)
        {
            loaderPanel = UIManager.UI.loaderUI;
            sceneLoader = loaderPanel.GetComponentInChildren<Slider>();
            progressText = sceneLoader.GetComponentInChildren<Text>();
            scenesManager = this;
            loaderPanel.SetActive(false);
            gameStarted = true;
        }

        
    }

    public void LoadMenu()
    {
        StaticStats.Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    public void Load(int idx)
    {
        StartCoroutine(LoadYourAsyncScene(idx));
    }

    public void UnLoad(int idx)
    {
        StartCoroutine(UnLoadYourAsyncScene(idx));
    }

    IEnumerator LoadYourAsyncScene(int idx)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idx);

        // Wait until the asynchronous scene fully loads
        loaderPanel.SetActive(true);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            sceneLoader.value = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
        loaderPanel.SetActive(false);


    }

    IEnumerator UnLoadYourAsyncScene(int idx)
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(idx);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
