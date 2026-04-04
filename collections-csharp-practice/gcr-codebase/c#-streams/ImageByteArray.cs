using System;
using System.IO;

class ImageByteArray
{
    static void Main()
    {
        try
        {
            byte[] imageBytes = File.ReadAllBytes("image.jpg");

            using MemoryStream ms = new MemoryStream(imageBytes);
            File.WriteAllBytes("copy.jpg", ms.ToArray());

            Console.WriteLine("Image copied successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
