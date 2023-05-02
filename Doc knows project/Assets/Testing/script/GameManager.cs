using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public InputField nameInput;
    public Button createButton;
    public Button playButton;

    private Account currentAccount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        createButton.onClick.AddListener(CreateAccount);
        playButton.onClick.AddListener(PlayAsAccount);
    }

    void Update()
    {
        UpdateScoreText();
    }

    void CreateAccount()
    {
        string name = nameInput.text;
        if (!string.IsNullOrEmpty(name))
        {
            AccountManager.instance.CreateAccount(name);
            nameInput.text = "";
        }
    }

    void PlayAsAccount()
    {
        string name = nameInput.text;
        if (!string.IsNullOrEmpty(name))
        {
            Account account = AccountManager.instance.GetAccount(name);
            if (account != null)
            {
                currentAccount = account;
                AccountManager.instance.PlayAsAccount(currentAccount);
            }
        }
    }

    void UpdateScoreText()
    {
        if (currentAccount != null)
        {
            scoreText.text = "Score: " + currentAccount.score.ToString();
        }
    }

    public void StartGame(Account account)
    {
        // Set up the game for the selected account
         PlayerScore.score = account.score;
        //
    }
}
