using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxToggle : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        UpdateButtonImage();
    }
    public void OnToggleSfx()
    {
        SfxManager.instance.ToggleSfxCorrect();
        SfxWrong.instance.ToggleSfxWrong();
        UpdateButtonImage();
    }
    private void UpdateButtonImage()
    {
        if (SfxManager.instance.isSfxCorrectOn && SfxWrong.instance.isSfxWrongOn)
        {
            image.sprite = soundOnSprite;
        }
        else
        {
            image.sprite = soundOffSprite;
        }
    }
}
