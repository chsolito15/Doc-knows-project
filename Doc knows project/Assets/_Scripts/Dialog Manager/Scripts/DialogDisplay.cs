using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;
    public GameObject speakerLeft,speakerRight, disableSwipe, disableShop, disableBody;
    private SpeakerUI speakerUILeft; 
    private SpeakerUI speakerUIRight;
    private int activeLineIndex = 0;

      void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
        speakerUILeft.Speacker = conversation.speakerLeft;
        speakerUIRight.Speacker = conversation.speakerRight;
        disableSwipe.SetActive(false);
        disableShop.SetActive(false);
        disableBody.SetActive(false);
    }

    public void AdvanceConversation()
    {
        if(activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            disableSwipe.SetActive(true);
            disableShop.SetActive(true);
            disableBody.SetActive(true);

        }
    }

     void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    void SetDialog(SpeakerUI activeSpeackerUI, SpeakerUI inactiveSpeackerUI, string text)
    {
        activeSpeackerUI.Dialog = text;
        activeSpeackerUI.Show();
        inactiveSpeackerUI.Dialog = text;
        inactiveSpeackerUI.Hide();
    }
}
