using System;

public class CrackerUtilityImpl : ICracker
{
    private char[] charset = { 'a', 'b', 'c', '1', '2' };
    private Vault vault;
    private bool found;
    private int attempts;
    private Random random = new Random();

    public CrackerUtilityImpl()
    {
        vault = new Vault("");
    }

    // user password
    public void CrackUserPassword(string password)
    {
        vault.SetPassword(password);
        StartCracking(password.Length);
    }
// random password cracker
    public void CrackRandomPassword(int length)
    {
        string randomPassword = GenerateRandomPassword(length);
        vault.SetPassword(randomPassword);

        Console.WriteLine("Randomly Generated Password: " + randomPassword);
        StartCracking(length);
    }

    // COMMON START 
    private void StartCracking(int length)
    {
        found = false;
        attempts = 0;

        char[] current = new char[length];
        Backtrack(0, current);

        Console.WriteLine("Total Attempts: " + attempts);
    }

    //  BACKTRACKING 
    private void Backtrack(int index, char[] current)
    {
        if (found)
            return;

        if (index == current.Length)
        {
            attempts++;
            string guess = new string(current);
            Console.WriteLine("Trying: " + guess);

            if (guess.Equals(vault.GetPassword()))
            {
                Console.WriteLine("\nPassword Cracked: " + guess);
                found = true;
            }
            return;
        }

        for (int i = 0; i < charset.Length; i++)
        {
            current[index] = charset[i];
            Backtrack(index + 1, current);

            // BACKTRACK
            current[index] = '\0';
        }
    }

    // RANDOM PASSWORD 
    private string GenerateRandomPassword(int length)
    {
        char[] pwd = new char[length];

        for (int i = 0; i < length; i++)
        {
            pwd[i] = charset[random.Next(charset.Length)];
        }

        return new string(pwd);
    }
}
