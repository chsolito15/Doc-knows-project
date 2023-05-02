using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public static int exp;
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
        if(exp < 0)
        {
            exp = 0;
        }
        expDisplay.text = "Score:" + exp.ToString();
    }

}
