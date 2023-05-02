using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onclick_shop : MonoBehaviour
{
    public GameObject popup_shop;
    private bool isPop = false;

    void Start()
    {
        popup_shop.SetActive(false);
    }
    public void Popup_shop()
    {
        if(isPop == false)
        {
            isPop = true;
            popup_shop.SetActive(true);
        }
        else if( isPop == true)
        {
            isPop = false;
            popup_shop.SetActive(false);
        }
    }

}
