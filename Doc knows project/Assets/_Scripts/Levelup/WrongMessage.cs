using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongMessage : MonoBehaviour
{
    public GameObject wrong;
    void Start()
    {
        wrong.SetActive(false);
    }

    public void Wrong()
    {
        wrong.SetActive(false);
        StartCoroutine(Waiting());
        wrong.SetActive(false);

    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.0f);
        wrong.SetActive(true);
    }
}
