using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NotificationLevelUp : MonoBehaviour
{
    public static NotificationLevelUp instance;
    public GameObject correctAnswer, wrongAnswer;
    public static int currentLevel;

    void Start()
    {
        correctAnswer.SetActive(false);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
           Destroy(instance);
        }
    }
    public void Notify_Correct()
    {     
        correctAnswer.SetActive(true);
        Invoke("WinPopUp", 2.0f);
    }
    void  WinPopUp()
    {
        correctAnswer.SetActive(false);
        Stage_Passed();
        Stage_One.Stage_reset();      
    }

    public void Notify_Wrong()
    {    
        wrongAnswer.SetActive(true);
        Invoke("LosePopUp", 2.0f);
    }

     void LosePopUp()
    {
        wrongAnswer.SetActive(false);
        Stage_One.Stage_reset();
    }

    private void Stage_Passed()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1 - 2;

        if (currentLevel > PlayerPrefs.GetInt("unlocked"))
        {
            PlayerPrefs.SetInt("unlocked", currentLevel);
            Debug.Log("Stage: " + PlayerPrefs.GetInt("unlocked") + " has been unlocked! ");
        }
    }
}
