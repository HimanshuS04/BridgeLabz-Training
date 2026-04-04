using System;

class NullPointExceptions
{
    static void Main(string[] args)
    {
        NullException();
    }
    static void NullException()
    {
        string str=null;
        try
        {
            int length=str.Length;
            Console.WriteLine("Length of the string :"+length);
        }
            catch(NullReferenceException ex){
                Console.WriteLine("Exception caught: " + ex.Message);

            }
        }
    }
