using System;
public class CelToFeh {
    static void Main(string[] args) {
        float cel = float.Parse(Console.ReadLine());
		float fah = (cel * 9 / 5) + 32;
		Console.WriteLine(fah);
    }
    
}
