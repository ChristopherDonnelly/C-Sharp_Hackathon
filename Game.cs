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
        Player redPlayer = new Player("Red Player");
        Player bluePlayer = new Player("Blue Player");
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
        public int ChooseCards()
        {
            int player1Card = this.PlayCard(redPlayer);
            int player2Card = this.PlayCard(bluePlayer);
            System.Console.WriteLine("\n Red Player played: " + player1Card);
            System.Console.WriteLine("Blue Player played: " + player2Card + "\n");
            int result = this.resultsTable[player1Card][player2Card];
            return result;
        }
        public int PlayCard(Player colorPlayer)
        {
            Card tempCard = new Card();
            bool cardAvailable = false;
            System.Console.WriteLine($"\n {colorPlayer} These are your cards: ");
            foreach(Card c in colorPlayer.hand){System.Console.WriteLine(c.value + " - " + c.name + " - " + c.desc);}
            System.Console.WriteLine($"\n {colorPlayer} What card will you play (enter card number)?");
            int playerInput = int.Parse(Console.ReadLine());
            foreach(Card c in colorPlayer.hand)
            {
                if(c.value == playerInput)
                {
                    tempCard = c;
                    cardAvailable = true;
                }
            }
            if(cardAvailable == false)
            {
                System.Console.WriteLine("That card has already been played. Choose another card.");
                return PlayCard(colorPlayer);
            }
            else
            {
                colorPlayer.playedCards.Add(tempCard);
                colorPlayer.hand.Remove(tempCard);
                return playerInput;
            }
        }

        public void DisplayRoundStats()
        {
            System.Console.WriteLine("\n ===========================STATS=============================");
            System.Console.WriteLine("Red player has played the following cards: ");
            // foreach(Card c in redPlayer.playedCards){System.Console.WriteLine(c.value + " - " + c.name + " - " + c.desc);}
            foreach(Card c in redPlayer.playedCards){System.Console.WriteLine(c.value + " - " + c.name);}
            System.Console.WriteLine("Red player rounds won (current game): " + this.redPlayer.roundsWon);
            System.Console.WriteLine("\n Blue player has played the following cards: ");
            // foreach(Card c in bluePlayer.playedCards){System.Console.WriteLine(c.value + " - " + c.name + " - " + c.desc);}
            foreach(Card c in bluePlayer.playedCards){System.Console.WriteLine(c.value + " - " + c.name);}
            System.Console.WriteLine("Blue player rounds won (current game): " + this.bluePlayer.roundsWon);
            System.Console.WriteLine("============================================================= \n");
        }
        public void DisplayGameStats()
        {
            System.Console.WriteLine("\n ===========================WINS=============================");
            System.Console.WriteLine("Red player game wins: " + this.redPlayer.gamesWon);
            System.Console.WriteLine("Blue player game wins: " + this.bluePlayer.gamesWon);
            System.Console.WriteLine("============================================================= \n");
        }
        public void CheckGameOver(Player colorPlayer,int result)
        {
            if(colorPlayer.roundsWon >= 4)
            {
                colorPlayer.gamesWon += 1;
                System.Console.WriteLine($"***** {colorPlayer} wins game! *****");
                this.hold = 0;
                this.DisplayGameStats();
                colorPlayer.roundsWon = 0;
                this.DealNewGame();
            }
            if(result == 3)
            {
                this.redPlayer.gamesWon += 1;
                this.hold = 0;
                this.DisplayGameStats();
                System.Console.WriteLine("***** Red player wins game! *****");
                this.redPlayer.roundsWon = 0;
                this.DealNewGame();
            }
            else if(result == 4)
            {
                this.bluePlayer.gamesWon += 1;
                this.hold = 0;
                this.DisplayGameStats();
                System.Console.WriteLine("***** Blue player wins game! *****");
                this.bluePlayer.roundsWon = 0;
                this.DealNewGame();
            }
            this.DisplayRoundStats();
            this.PlayRound();
        }
        public void DealNewGame()
        {
                this.redPlayer.resetCards();
                this.bluePlayer.resetCards();
                this.redPlayer.hand = gameDeck.dealCards();
                this.bluePlayer.hand = gameDeck.dealCards();
                this.PlayRound();
        }
        public void TallyResults(int result)
        {
            if(result == 0)
            {
                System.Console.WriteLine("This round is on hold!");
                this.hold += 1;
                System.Console.WriteLine("Rounds on hold: " + this.hold);
                this.PlayRound();
            }
            else if(result == 1)
            {
                System.Console.WriteLine("Red Player Wins round!");
                this.redPlayer.roundsWon += 1 + this.hold;
                this.hold = 0;
                this.CheckGameOver(this.redPlayer,result);
            }
            else if(result == 2)
            {
                System.Console.WriteLine("Blue Player Wins round!");
                this.bluePlayer.roundsWon += 1 + this.hold;
                this.hold = 0;
                this.CheckGameOver(this.bluePlayer,result);
            }  
            else
            {
                this.CheckGameOver(this.bluePlayer,result);
            }
        }
    }
}
