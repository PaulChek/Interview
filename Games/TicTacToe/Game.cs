using System;
using System.Linq;

namespace TicTacToe {
    class Game {
        public Board CurrentBoard { get; set; }
        public Random Rand { get; set; }
        public Game() {
            InitGame();
            CurrentBoard.DisplayBoard();
            FirstMove();
            PlayGame();
            CheckStatus();

        }

        private void InitGame() {
            Rand = new Random();
            CurrentBoard = new Board();
        }

        private void FirstMove() {
            Console.WriteLine("Who start? 1 - computer, 2 - user:" );
            var res =  Console.ReadLine();
            if (res == "1") { 
                var cell = new Cell((Rand.Next(0, Program.size), Rand.Next(0, Program.size)));
                CurrentBoard.Move(cell, 1); //comp
                CurrentBoard.DisplayBoard();
            }
        }

        private void PlayGame() {
            while (CurrentBoard.IsRunning()) {
                Console.WriteLine("User move:");
                Cell UserCell = new Cell(CurrentBoard.GetCorrdinatesFromInput());

                CurrentBoard.Move(UserCell, 2);
                CurrentBoard.DisplayBoard();
                if (!CurrentBoard.IsRunning()) break;

                CurrentBoard.InvokeMiniMax(0, 1);

                foreach (Cell cell in CurrentBoard.Cells) 
                    Console.WriteLine(cell);

                CurrentBoard.Move(CurrentBoard.GetBestMove(), 1); //comp

                CurrentBoard.DisplayBoard();
            }
        }

        void CheckStatus() {
            if (CurrentBoard.IsWinning(1)) Console.WriteLine("Computer Won");
            else if (CurrentBoard.IsWinning(2)) Console.WriteLine("User Won");
            else Console.WriteLine("Draw");
        }
    }
}
