using System;
using System.Diagnostics;
using System.IO;

class BufferedVsUnbuffered
{
    static void Main()
    {
        string source = "largefile.dat";
        string destBuffered = "bufferedCopy.dat";
        string destNormal = "normalCopy.dat";

        byte[] buffer = new byte[4096];

        Stopwatch sw = new Stopwatch();

        // Normal FileStream
        sw.Start();
        using (FileStream fsRead = new FileStream(source, FileMode.Open))
        using (FileStream fsWrite = new FileStream(destNormal, FileMode.Create))
        {
            int bytes;
            while ((bytes = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                fsWrite.Write(buffer, 0, bytes);
        }
        sw.Stop();
        Console.WriteLine("Unbuffered Time: " + sw.ElapsedMilliseconds);

        // Buffered Stream
        sw.Restart();
        using (BufferedStream br = new BufferedStream(new FileStream(source, FileMode.Open)))
        using (BufferedStream bw = new BufferedStream(new FileStream(destBuffered, FileMode.Create)))
        {
            int bytes;
            while ((bytes = br.Read(buffer, 0, buffer.Length)) > 0)
                bw.Write(buffer, 0, bytes);
        }
        sw.Stop();
        Console.WriteLine("Buffered Time: " + sw.ElapsedMilliseconds);
    }
}
