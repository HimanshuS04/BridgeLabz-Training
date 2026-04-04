using System;
class AverageMark{
	static void Main(string[] args){
	int maths=94;
	int physics=95;
	int chemistry=96;
	double avg=maths+physics+chemistry;
    double average=(avg/300.0)*100;
    Console.WriteLine("Sam’s average mark in PCM is "+ average+"%");
   }
}