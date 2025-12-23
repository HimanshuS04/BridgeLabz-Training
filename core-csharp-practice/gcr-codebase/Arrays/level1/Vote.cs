// using System;
// class Vote
// {
//     static void Main(string[] args)
//     {
//         int[] ages= new int[10];
//         for(int i = 0; i < ages.Length; i++)
//         {
//             ages[i]=int.Parse(Console.ReadLine());
//         }
//         for(int j = 0; j < ages.Length; j++)
//         {
//             if (ages[j] <18 && ages[j]>0)
//             {
//                 Console.WriteLine($"The student with age {ages[j]} can not vote");
//             }
//             else if (ages[j] >= 18)
//             {
//                 Console.WriteLine($"The student with age {ages[j]} can vote");

//             }
//             else
//             {
//                 Console.WriteLine("invalid age");
//             }
//         }
//     }
// }