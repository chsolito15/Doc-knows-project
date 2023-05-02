using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_One : MonoBehaviour
{
    public Transform rightMedicine;
    public Transform wrongMedicine;
    public Transform spriteNone;
    private Vector2 mousePosition;
    private float deltaX;
    private float deltaY;
    private static bool locked;

    void Start()
    {
        mousePosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - rightMedicine.position.x) <= 150.5f && Mathf.Abs(transform.position.y - rightMedicine.position.y) <= 150.5f)
        {
            NotificationLevelUp.instance.Notify_Correct();
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
            PlayerMoney.money += 200;
            PlayerScore.score += 2000;        
            SfxManager.instance.CorrectMessage();
            Destroy(rightMedicine.gameObject);
            Destroy(gameObject);
            locked = true;
        }
        else if (Mathf.Abs(transform.position.x - wrongMedicine.position.x) <= 150.5f && Mathf.Abs(transform.position.y - wrongMedicine.position.y) <= 150.5f)
        {
            NotificationLevelUp.instance.Notify_Wrong();
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
            Destroy(wrongMedicine.gameObject);      
            SfxWrong.instance.WrongMessage();
            Destroy(gameObject);
            locked = true;
        }
        else if(Mathf.Abs(transform.position.x - spriteNone.position.x) <= 150.5f && Mathf.Abs(transform.position.y - spriteNone.position.y) <= 150.5f)
        {
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
        else
        {
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    public static void Stage_reset() 
    {
        SceneManager.LoadScene(2);
        locked = false;
    }

    public void toVillage() 
    {
        SceneManager.LoadScene(1);     
    }
}
