using System;
class SnakeLadderGame
{
    static Random random=new Random();
    static int[] snakeStart={16,47,49,56,67,88,99};
    static int[] snakeEnd={6,26,11,53,25,24,78};
     static int[] ladderStart={7,8,15,28,36,51,71};
    static int[] ladderEnd={17,27,45,50,70,77,90};
    static void Main(string[] args){
        int NoOfPlayer;
        do
        {
            Console.WriteLine("Enter number of players from (2 to 4):");
            NoOfPlayer=int.Parse(Console.ReadLine());
        }
        while(NoOfPlayer<2 || NoOfPlayer > 4);
        
        int[] playerPositions=new int[NoOfPlayer];
        string[] players=new string[NoOfPlayer];
        //input the player names
        for(int i=0;i<NoOfPlayer;i++)
        {
            Console.WriteLine("Enter name of player "+(i+1)+":");
            players[i]=Console.ReadLine();
            playerPositions[i]=0; //initial at 0;
        }
        bool winnerFound=false;
        while (!winnerFound)
        {
            for(int i = 0; i < players.Length; i++)
            {
              Console.WriteLine(players[i]+" turn. Press Enter to roll the dice.");  
              Console.ReadLine();
              int diceValue=RollDice();
              Console.WriteLine(players[i]+" rolled a "+diceValue);
              int oldPosition=playerPositions[i];
              int newPosition=oldPosition + diceValue;
                if (newPosition > 100)
                {
                    Console.WriteLine(players[i]+" move exceed 100.will stay at old position anmd turn skiiped");
                    continue;
                }
                playerPositions[i]= newPosition;
                playerPositions[i]=LadderAndSnake(playerPositions[i]);
                Console.WriteLine(players[i]+" moved from "+oldPosition+" to "+newPosition);
                if(CheckWinner(playerPositions[i]))
                {
                    Console.WriteLine(players[i]+" has won the game! Congratulations!");
                    winnerFound=true;
                    break;
            }
        }
    }
    Console.WriteLine("Game Over!");
    }   
    
    static int RollDice()
    {
        return random.Next(1,7);//btw 1 to 6
    }

    static int LadderAndSnake(int position)
    {
       // for ladder
       for(int i=0;i<ladderStart.Length;i++)
       { 
        if(position==ladderStart[i])
        {
            Console.WriteLine("Hurray! You climbed a ladder from "+ladderStart[i]+" to "+ladderEnd[i]);
            return ladderEnd[i];
        }
       }
       //for snake 
       for(int i=0;i<snakeStart.Length;i++)
       {
        if(position==snakeStart[i])
        {
            Console.WriteLine("Oops! You got bitten by a snake from "+snakeStart[i]+" to "+snakeEnd[i]);
            return snakeEnd[i];
        }
       }
       return position;
    }
    static bool CheckWinner(int position)
    {
        return position==100?true:false;
    }
}

