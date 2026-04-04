using System;
public class Vault
{
    private string Password;
    public Vault(string password)
    {
        Password = password;
    }
    public string GetPassword()
    {
        return Password;
    }
    public void SetPassword(string password)
    {
        Password = password;
    }
    public override string ToString()
    {
        return "Vault Password: " + Password;
    }
}