using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;
    public List<Account> accounts;

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

    public void CreateAccount(string name)
    {
        Account newAccount = new Account(name);
        accounts.Add(newAccount);
    }

    public Account GetAccount(string name)
    {
        foreach (Account account in accounts)
        {
            if (account.name == name)
            {
                return account;
            }
        }
        return null;
    }

    public void PlayAsAccount(Account account)
    {
        GameManager.instance.StartGame(account);
    }
}
