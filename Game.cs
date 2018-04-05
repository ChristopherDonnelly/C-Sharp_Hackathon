using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hackathon_Day
{
    public class Game
    {
        int hold;
        Deck gameDeck = new Deck();
        Player redPlayer = new Player();
        Player bluePlayer = new Player();
        string[] result = {"Hold","Red wins round","Blue wins round","Red wins game","Blue wins game","General bonus strength"};
        int[][] resultsTable = new int[][] {
            new int[] {0,0,0,0,0,2,0,0},
            new int[] {0,0,2,1,2,2,2,3},
            new int[] {0,1,0,1,2,2,2,2},
            new int[] {0,2,2,0,1,2,1,2},
            new int[] {0,1,1,2,0,2,2,2},
            new int[] {1,1,1,1,1,0,2,2},
            new int[] {0,1,1,2,1,1,0,2},
            new int[] {0,4,1,1,1,1,1,0}
        };
        public void PlayRound()
        {
            int roundresult = this.ChooseCards();
            this.TallyResults(roundresult);
        }
        public int PlayCard()
        {
            System.Console.WriteLine("What card will you play (number 0-7)?");
            int playerInput = int.Parse(Console.ReadLine());
            return playerInput;
        }
        public int ChooseCards()
        {
            System.Console.WriteLine("Player 1");
            int player1Card = this.PlayCard();
            System.Console.WriteLine("Player 2");
            int player2Card = this.PlayCard();
            System.Console.WriteLine("Player 1 played: " + player1Card);
            System.Console.WriteLine("Player 2 played: " + player2Card);
            int result = this.resultsTable[player1Card][player2Card];
            return result;
        }
        public void CheckGameOver(Player colorPlayer,int result)
        {
            if(colorPlayer.roundsWon >= 4)
            {
                colorPlayer.gamesWon += 1;
                colorPlayer.roundsWon = 0;
                this.DealNewGame();
            }
            if(result == 3)
            {
                this.redPlayer.gamesWon += 1;
                this.redPlayer.roundsWon = 0;
                this.DealNewGame();
            }
            else if(result == 4)
            {
                this.bluePlayer.gamesWon += 1;
                this.bluePlayer.roundsWon = 0;
                this.DealNewGame();
            }
            this.PlayRound();
        }
        public void DealNewGame()
        {
                this.redPlayer.resetCards();
                this.bluePlayer.resetCards();
                this.redPlayer.hand = gameDeck.dealCards();
                this.bluePlayer.hand = gameDeck.dealCards();
                this.ChooseCards();
        }
        public void TallyResults(int result)
        {
            if(result == 0)
            {
                this.hold += 1;
            }
            else if(result == 1)
            {
                System.Console.WriteLine("Red Player Wins!");
                this.redPlayer.roundsWon += 1;
                this.CheckGameOver(this.redPlayer,result);
            }
            else if(result == 2)
            {
                System.Console.WriteLine("Blue Player Wins!");
                this.bluePlayer.roundsWon += 1;
                this.CheckGameOver(this.bluePlayer,result);
            }  
        }
    }
}
