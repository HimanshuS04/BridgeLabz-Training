using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

    public class RegistrationService : IRegistrationService
    {
        private static readonly object lockObj = new object();
        private string filePath = "RegisteredEmails.txt";

        public void RegisterEmail(string email)
        {
            Thread thread = new Thread(() =>
            {
                ProcessEmail(email);
            });

            thread.Start();
            thread.Join();
        }

        private void ProcessEmail(string email)
        {
            try
            {
                Student student = new Student(email);

                if (EmailUtility.ValidateEmail(student, out var results))
                {
                    Console.WriteLine(" Valid Email Registered");

                    lock (lockObj)
                    {
                        File.AppendAllText(filePath, email + Environment.NewLine);
                    }
                }
                else
                {
                    Console.WriteLine(" Invalid Email");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

