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
        wrongAnswer.SetActive(false);
     
        if (instance == null)
        {
            instance = this;        
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(correctAnswer);
            DontDestroyOnLoad(wrongAnswer);
        }

    }
    public void Notify_Correct() // trigger modal  correct message
    {     
        correctAnswer.SetActive(true);
        Invoke("WinModal", 2.0f);
    }
    void  WinModal()
    {
        correctAnswer.SetActive(false);
        Stage_Passed();
        Stage_One.indexStages();      
    }

    public void Notify_Wrong() // trigger modal wrong message 
    {    
        wrongAnswer.SetActive(true);
        Invoke("LoseModal", 2.0f);
    }

     void LoseModal()
    {
        wrongAnswer.SetActive(false);
        Stage_One.indexStages();
    }

    private void Stage_Passed() // unlocked stages if answer was correct
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1 - 2;

        if (currentLevel > PlayerPrefs.GetInt("unlocked"))
        {
            
           PlayerPrefs.SetInt("unlocked", currentLevel);
           Debug.Log("Stage: " + PlayerPrefs.GetInt("unlocked") + " has been unlocked! ");
            
        }

        if (currentLevel >= 9)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }

    }
}
