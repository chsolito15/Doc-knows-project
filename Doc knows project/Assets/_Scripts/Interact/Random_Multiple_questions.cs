using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_Multiple_questions : MonoBehaviour
{
    public List<Button> buttons;   // Every click Quize stages automatically medicine choices will place randomly
    void Start()
    {
        RandomiseButtons();
    }
    public void RandomiseButtons()
    {
        foreach (Button button in buttons)
            button.transform.SetSiblingIndex(Random.Range(0, buttons.Count));
    }
}
