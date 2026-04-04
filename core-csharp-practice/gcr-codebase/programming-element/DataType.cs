using System;
class DataType{
	static void Main(string[] args){
	int num=65;
	double dNum=3.0;
	float fNum=4.0f;
	char ch='B';
	String s="Hello, how are you";
	bool boolVal= true;

	Console.WriteLine("int :"+num);
	Console.WriteLine("double :"+dNum);
	Console.WriteLine("float :"+fNum);
	Console.WriteLine("char :"+ch);
	Console.WriteLine("String :"+s);
	Console.WriteLine("bool :"+boolVal);


    //implicit typecasting integer to double and float
	double dd = num;
	Console.WriteLine("int to double "+dd);

	float ff=num;
	Console.WriteLine("int to float" + ff);
	 
	//explicit typecasting int to char
	char cc=(char)num;
	Console.WriteLine("int to char "+ cc);

	String ss=num.ToString();
	Console.WriteLine("int ot string "+ss);

	//typecasting double to integer,float,char,String

	int a1=(int)dNum;
	Console.WriteLine("double to int "+a1);
	float f1=(float)dNum;
	Console.WriteLine("double to float "+f1);
	char c1=(char)dNum;
	Console.WriteLine("double to char "+c1);
	String s1=dNum.ToString();
	Console.WriteLine("double to String "+s1);

    //typecasting float to integer,double,char,string
        int a2 = (int)fNum;
        System.Console.WriteLine("float to int: " + a2);

        double d2 = fNum;
        System.Console.WriteLine("float to double: " + d2);

        char c2 = (char)fNum;
        System.Console.WriteLine("float to char: " + c2);

        string s2 = fNum.ToString();
        System.Console.WriteLine("float to string: " + s2);

        

        // bool to string
        string s3 = boolVal.ToString();
        System.Console.WriteLine("bool to string: " + s3);

       
	}
}
