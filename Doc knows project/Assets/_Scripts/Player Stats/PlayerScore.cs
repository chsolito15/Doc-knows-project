using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static int score; 
    public Text expDisplay;

    void Start()
    {
        expDisplay = GetComponent<Text>();
    }

    void Update()
    {
        ExpAmount();
    }

    public void ExpAmount()
    {
        if (score < 0)
        {
            score = 0;
        }
        expDisplay.text = "Score:" + score.ToString();
    }
}
