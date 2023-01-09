using System;
using System.Collections.Generic;
using System.Text;
 
namespace TicTacToe
{
    public class Player
    {
        public string Name { get; set; }
        public string Marker { get; set; }
        public int Rating = 0;
 
        public bool IsTurn { get; set; }
        public List<GameHistory> History = new List<GameHistory>();
 
        
        public void WinGame(string OpponentName, Game game)
        {
            var currentGame = new GameHistory(game.GameRating, OpponentName, true);
            History.Add(currentGame);
        }
        public void LoseGame(string OpponentName, Game game)
        {
            var currentGame = new GameHistory(-game.GameRating, OpponentName, false);
            History.Add(currentGame);
        }
        
        public Positions GetPosition(PlayArea board)
        {
            Positions desiredCoordinate = null;
            while (desiredCoordinate is null)
            {
                Console.WriteLine("Виберіть позицію");
                Int32.TryParse(Console.ReadLine(), out int position);
                desiredCoordinate = PositionForNumber(position);
            }
            return desiredCoordinate;
 
        }
 
        public static Positions PositionForNumber(int position)
        {
            switch (position)
            {
                case 1: return new Positions(0, 0); 
                case 2: return new Positions(0, 1); 
                case 3: return new Positions(0, 2); 
                case 4: return new Positions(1, 0); 
                case 5: return new Positions(1, 1); 
                case 6: return new Positions(1, 2); 
                case 7: return new Positions(2, 0); 
                case 8: return new Positions(2, 1); 
                case 9: return new Positions(2, 2); 
 
                default: return null;
            }
        }
 
        public void TakeTurn(PlayArea board)
        {
            IsTurn = true;
 
            Console.WriteLine($"{Name} твоя черга");
 
            Positions position = GetPosition(board);
 
            if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _))
            {
                board.GameBoard[position.Row, position.Column] = Marker;
            }
            else
            {
                Console.WriteLine("Це місце вже зайнято");
            }
        }
    }
}