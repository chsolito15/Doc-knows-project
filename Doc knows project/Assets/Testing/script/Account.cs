
[System.Serializable]
public class Account
{
    public string name;
    public int score;

    public Account(string name)
    {
        this.name = name;
        score = 0;
    }
}

