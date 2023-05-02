using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        UpdateButtonImage();
    }
    public void OnToggleSound()
    {
        SoundManager.instance.ToggleSound();
        UpdateButtonImage();
    }
    private void UpdateButtonImage()
    {
        if (SoundManager.instance.isSoundOn)
        {
            image.sprite = soundOnSprite;
        }
        else
        {
            image.sprite = soundOffSprite;
        }
    }
}
