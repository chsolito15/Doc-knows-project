using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerAccountManager : MonoBehaviour
{
    public InputField usernameInputField;
    public Button createButton;
    public Button updateButton;
    public Button deleteButton;

    public Dropdown accountDropdown;

    private List<string> accountNames = new List<string>();

    private void Start()
    {
        // Load account names from PlayerPrefs and populate dropdown
        // LoadAccounts();
        PopulateDropdown();
    }

    public void CreateAccount()
    {
        string username = usernameInputField.text;

        if (string.IsNullOrEmpty(username))
        {
            Debug.LogError("Username is empty");
            return;
        }

        // Save account name to PlayerPrefs and update dropdown
        PlayerPrefs.SetString(username, username);
        accountNames.Add(username);
        PopulateDropdown();
    }

    public void UpdateAccount()
    {
        string oldUsername = accountDropdown.options[accountDropdown.value].text;
        string newUsername = usernameInputField.text;

        if (string.IsNullOrEmpty(newUsername))
        {
            Debug.LogError("Username is empty");
            return;
        }

        // Update account name in PlayerPrefs and dropdown
        PlayerPrefs.DeleteKey(oldUsername);
        PlayerPrefs.SetString(newUsername, newUsername);

        int index = accountNames.FindIndex(name => name == oldUsername);
        accountNames[index] = newUsername;

        PopulateDropdown();
    }

    public void DeleteAccount()
    {
        string username = accountDropdown.options[accountDropdown.value].text;

        // Delete account name from PlayerPrefs and dropdown
        PlayerPrefs.DeleteKey(username);
        accountNames.Remove(username);

        PopulateDropdown();
    }

    public void SelectAccount()
    {
        string username = accountDropdown.options[accountDropdown.value].text;
        Debug.Log("Selected account: " + username);

        // Use selected account for game
    }

  /* 
    private void LoadAccounts()
    {
        // Load account names from PlayerPrefs
        foreach (string key in PlayerPrefs.HasKey)
        {
            accountNames.Add(PlayerPrefs.GetString(key));
        }
    }
  */
    private void PopulateDropdown()
    {
        accountDropdown.ClearOptions();
        accountDropdown.AddOptions(accountNames);
    }
}
