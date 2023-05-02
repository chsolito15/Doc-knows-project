using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static int money;
    public Text amountText; 
    void Start()
    {
        amountText = GetComponent<Text>();
        money = PlayerPrefs.GetInt("money", 2000);
    }
    void Update()
    {
        MoneyAmount();
    }
    public void MoneyAmount()
    {
        if(money < 0)
        {
            money = 0;
        }

        amountText.text = money.ToString();
        PlayerPrefs.SetInt("money", money);
    }
}
