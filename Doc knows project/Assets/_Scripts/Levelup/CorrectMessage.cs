using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectMessage : MonoBehaviour
{
    public GameObject correct;
    
    void Start()
    {
        correct.SetActive(false);
       
    }
    public void Correct()
    {
        correct.SetActive(false);
        StartCoroutine(Waiting());
        correct.SetActive(false);
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.0f);
        correct.SetActive(true);     
    }
}
