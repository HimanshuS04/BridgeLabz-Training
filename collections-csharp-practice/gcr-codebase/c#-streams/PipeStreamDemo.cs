using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class PipeStreamDemo
{
    static void Main()
    {
        AnonymousPipeServerStream server =
            new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);

        AnonymousPipeClientStream client =
            new AnonymousPipeClientStream(PipeDirection.In, server.GetClientHandleAsString());

        new Thread(() =>
        {
            byte[] msg = Encoding.UTF8.GetBytes("Hello from Writer");
            server.Write(msg, 0, msg.Length);
            server.Close();
        }).Start();

        new Thread(() =>
        {
            byte[] buffer = new byte[256];
            int read = client.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, read));
        }).Start();
    }
}
