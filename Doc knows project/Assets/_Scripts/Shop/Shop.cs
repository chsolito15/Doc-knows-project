using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
                                    
    public Text bookDisplay, dividedDisplay;             // buy 50/50 divide questions by 2 so  player had 2 choises for choose correct answer  
    public Button buyDividedChoices, buyBookAnswer;  
    public GameObject revealAnswer, hideChoise1, hideChoise2;
    
   
    void Start()
    {
        PlayerPrefs.GetInt("money");
        revealAnswer.SetActive(false); 
        hideChoise1.SetActive(true);
        hideChoise2.SetActive(true);
    }
    void Update()
    {
        bookDisplay.text = PlayerMoney.money.ToString();

        if(PlayerMoney.money >= 1000)
        {
            buyBookAnswer.interactable = true;      // buy answer reveal
        }
        else
        {
            buyBookAnswer.interactable = false;
        }

        dividedDisplay.text = PlayerMoney.money.ToString();

        if (PlayerMoney.money >= 2000)
        {
            buyDividedChoices.interactable = true;      // Buy 50/50
        }
        else
        {
            buyDividedChoices.interactable = false;
        }
    }

    public void BuyBook()
    {
        PlayerMoney.money -= 2000;
        PlayerPrefs.SetInt("money", PlayerMoney.money);
        buyBookAnswer.gameObject.SetActive(false);
        revealAnswer.SetActive(true);
        StartCoroutine(DisAppear());
    }

    IEnumerator DisAppear()
    {      
        yield return new WaitForSeconds(2f);
        revealAnswer.SetActive(false);
    }

    public void DevidedAnswer()
    {
        PlayerMoney.money -= 1000;
        PlayerPrefs.SetInt("money", PlayerMoney.money);
        buyDividedChoices.gameObject.SetActive(false);
        hideChoise1.SetActive(false);
        hideChoise2.SetActive(false);
    }

   
}
