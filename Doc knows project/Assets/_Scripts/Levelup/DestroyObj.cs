using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
     
    public void Popup1()
    {  
        if(obj1.activeInHierarchy == false)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
        }
        else
        {
            obj1.SetActive(false);
        }
    }


    public void Popup2()
    {
        if (obj2.activeInHierarchy == false)
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);
            obj4.SetActive(false);
        }
        else
        {
            obj2.SetActive(false);
           
        }
    }

    public void Popup3()
    {
        if (obj3.activeInHierarchy == false)
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
            obj4.SetActive(false);
        }
        else
        {
            obj3.SetActive(false);

        }
    }

    public void Popup4()
    {
        if (obj4.activeInHierarchy == false)
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(true);
        }
        else
        {
            obj4.SetActive(false);

        }
    }

}
