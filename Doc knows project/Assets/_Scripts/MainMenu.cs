using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressTxt;

    public int levels_Unlocked;
    public Button[] buttons;
    void Start()
    {
        levels_Unlocked = PlayerPrefs.GetInt("unlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levels_Unlocked; i++)
        {
            buttons[i].interactable = true;
        }
        loadingScreen.SetActive(false);
    }
    public void Load_Map(int scenes)
    {
        StartCoroutine(LoadAsynchronously(scenes));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        slider.value = 0;
        AsyncOperation asynLoad = SceneManager.LoadSceneAsync(sceneIndex);  // Create an AsyncOperation object to load the scene
        loadingScreen.SetActive(true);
        asynLoad.allowSceneActivation = false;  // Disable scene activation so that the new scene doesn't start immediately
        float progress = 0;
        
        while (!asynLoad.isDone)  // Loop until the progress reaches 0.9, which means the scene is almost loaded
        {        
            progress = Mathf.MoveTowards(progress, asynLoad.progress, Time.deltaTime);
            progressTxt.text = Mathf.Round(progress * 100f) + " % ";
            slider.value = progress;

            if (progress >= 0.9f)
            {
                slider.value = 1;
                progressTxt.text = "100%";
                asynLoad.allowSceneActivation = true;
            }     
            yield return null;
        }
    }

}
