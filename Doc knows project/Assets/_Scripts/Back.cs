using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    private int sceneIndex;
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void onClickBack()
    {
        SceneManager.LoadScene(sceneIndex - 1);
    }
}
