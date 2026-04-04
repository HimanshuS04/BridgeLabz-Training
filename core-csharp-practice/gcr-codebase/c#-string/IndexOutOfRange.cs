using system;
class IndexOutOfRange
{
    static void Main(string[] args)
    {
        IndexException();
    }
    static void IndexException()
    {
        string str="Hello, World!";
        try
        {
            char ch=str[20];
            Console.WriteLine("Character at index 20 :"+ch);
        }
            catch(IndexOutOfRangeException ex){
                Console.WriteLine("Exception caught: " + ex.Message);

            }
        }
    }