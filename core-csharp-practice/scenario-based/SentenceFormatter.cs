using System;
class SentenceFommatter
{
    static void Main(string[] args)
    {
        Console.WriteLine(" 1 .sentence formatter");
        Console.WriteLine("2. Analizing a paragraph");
        int choice=int.Parse(Console.ReadLine());
        switch(choice)
        {
            case 1:
            {

                string paragraph=TakeParagraph();
                string result=FormatedSenetence(paragraph);
                Console.WriteLine(result);
                break;
            }
            case 2:
            {
                string paragraph1=TakeParagraph();
                ParaAnalizer(paragraph1);
                break;
            }
            default:
            {
                Console.WriteLine("Invalid choice");
                break;
            }
        }

    }

    static string TakeParagraph()
    {
        Console.WriteLine("Enter a paragraph:");
        return Console.ReadLine();
    }
    static string FormatedSenetence(string paragraph)
    {
    string result="";
    bool captilizeNext=true;
    paragraph=paragraph.Trim();
    
     for(int i = 0; i < paragraph.Length; i++)
        {
            char current=paragraph[i];
            //skip extra spaces
            if(current==' ' && result.Length>0 && result[result.Length-1]==' ')
            {
                continue;
            }
            //punctuation handling
            if(current=='.' || current=='!' || current=='?')
            {
                result+=current;
                result+=' ';
                captilizeNext=true;   
              //skip extra spaces after punctuation
                while(i+1<paragraph.Length && paragraph[i+1]==' ')
                {
                    i++;
                }
          }
          else if(IsLetter(current))
            {
                if(captilizeNext)
                {
                    result+=ToUpperCase(current);
                    captilizeNext=false;
                }
                else
                {
                    result+=ToLowerCase(current);
                }
            }
            else
            {
                result+=current;
            }
        }
    return result.Trim();
    }
    //to make uppercase
    static char ToUpperCase(char current)
    {
        if(current>='a' && current <= 'z')
        {
            return (char)(current-32);
        }
        return current;

    }
    //to make lowercase
    static char ToLowerCase(char current)
    {
        if(current>='A' && current <='Z')
        {
            return (char)(current+32);
        }
        return current;
    }

    static bool IsLetter(char ch)
    {
        return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
    }



// analize paragraph part 2
static void ParaAnalizer(string paragraph1)
    {
        if(paragraph1==null || paragraph1.Length==0)
        {
            Console.WriteLine("Empty paragraph");
            return;
        }
        string[] words=SplitIntoWords(paragraph1);
        Console.WriteLine("enter old word to be replaced:");
        string oldWord=Console.ReadLine();
        Console.WriteLine("enter new word to replace:");
        string newWord=Console.ReadLine();  
        string replacedParagraph=ReplaceWord(words,oldWord,newWord);
        Console.WriteLine("Replaced Paragraph:");
        Console.WriteLine(replacedParagraph);

        Console.WriteLine("Largest word in the paragraph:");
        string largestWord=LargestWord(words);
        Console.WriteLine(largestWord);

        Console.WriteLine("Total word count in the paragraph:");
        int wordCount=CountWords(words);
        Console.WriteLine(wordCount);
    }

    //function to convert to word array
    static string[] SplitIntoWords(string paragraph1)
    {
        return paragraph1.Trim().Split(' ');
    }
    //replace word in paragraph
      static string ReplaceWord(string[] words,string oldWord,string newWord)
    {
    string result="";
    for(int i=0;i<words.Length;i++)
        {
            if (ToLowerString(words[i]) == ToLowerString(oldWord))
            {
                result+=newWord+" ";
            }
            else
            {
                result+=words[i]+" ";
            }
        }
        return result.Trim();
}
//find largest word in paragraph
static string LargestWord(string[] words)
    {
        string largest=words[0];
        for(int i=1;i<words.Length;i++)
        {
            if(words[i].Length>largest.Length)
            {
                largest=words[i];
            }
        }
        return largest;
    }

    // word count 
    static int CountWords(string[] words)
    {
        int count = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length>0 )
                count++;
        }
        return count;
    }
    //to lower case string
       static string ToLowerString(string word)
    {
        string lower = "";
        for (int i = 0; i < word.Length; i++)
            lower += ToLowerCase(word[i]);
        return lower;
    }
}

