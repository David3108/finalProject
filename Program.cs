using TicTacToe;
using System;
 
namespace TicTacToe
{
   public class Program
   {
       static void Main(string[] args)
       {
           StartGame();
       }
       static void StartGame()
       {
           Console.Write("Гравець 1: Введіть імя: ");
           string playerOne = Console.ReadLine();
           Console.Write("Гравець 2: Введіть імя:");
           string playerTwo = Console.ReadLine();
 
           InstantiateGame(playerOne, playerTwo);
       }

       static void Stats(Player p1, Player p2)
       {
           int i = 0;
           Console.WriteLine("Player\t" + "Game Rating\t" + "Result\t" + "GameID");
           Console.WriteLine($"{p1.Name}\t  {p1.History[i].GameRating}\t \t  {p1.History[i].Result}\t  {p1.History[i].GameID}");
           Console.WriteLine($"{p2.Name}\t  {p2.History[i].GameRating}\t \t {p2.History[i].Result}\t  {p2.History[i].GameID}");
       }

       static void InstantiateGame(string p1, string p2)
       {
           Player playerOne = new Player()
           {
               Name = p1,
               Marker = "X",
               IsTurn = true
 
           };
 
           Player playerTwo = new Player()
           {
               Name = p2,
               Marker = "O",
               IsTurn = false
 
           };
           Console.Clear();
 
           Game newGame = new Game(playerOne, playerTwo);
 
           Player winner = newGame.Play();
           String loser = (winner.Name == playerOne.Name ? playerTwo.Name : playerOne.Name);
 
 
           if (!(winner is null) & (winner == playerOne))
           {
               playerOne.WinGame(playerTwo.Name, newGame);
               playerTwo.LoseGame(playerOne.Name, newGame);
               Console.WriteLine($"{winner.Name} Виграв!");
           }
           
           if (!(winner is null) & (winner == playerTwo))
           {
               playerTwo.WinGame(playerOne.Name, newGame);
               playerOne.LoseGame(playerTwo.Name, newGame);
               Console.WriteLine($"{winner.Name} Виграв!");
           } else if(winner is null)
               Console.WriteLine("Нічия!");

           Stats(playerOne,playerTwo);
       }
   }
 
 
}
