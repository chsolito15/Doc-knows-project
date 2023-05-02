using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevel : MonoBehaviour
{
    public static int currentLevel;
    public void Passed()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1 - 2;

        if(currentLevel > PlayerPrefs.GetInt("unlocked"))
        {
            PlayerPrefs.SetInt("unlocked", currentLevel);
            Debug.Log("Level: " + PlayerPrefs.GetInt("unlocked") + "Unlocked");
        }
    }
}
