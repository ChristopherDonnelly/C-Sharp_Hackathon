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
            
            Console.ForegroundColor = ConsoleColor.Red;
            int player1Card = this.PlayCard(redPlayer);
            
            Console.ForegroundColor = ConsoleColor.Blue;
            int player2Card = this.PlayCard(bluePlayer);
            // System.Console.WriteLine("\nRed Player played: " + player1Card);
            // System.Console.WriteLine("Blue Player played: " + player2Card + "\n");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red Player played: ");
            Console.WriteLine(redPlayer.playedCards[redPlayer.playedCards.Count-1]);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Blue Player played: ");
            Console.WriteLine(bluePlayer.playedCards[bluePlayer.playedCards.Count-1]);
            
            Console.ForegroundColor = ConsoleColor.White;

            int result = this.resultsTable[player1Card][player2Card];
            return result;
        }
        public int PlayCard(Player colorPlayer)
        {
            Card tempCard = new Card();
            bool cardAvailable = false;

            Console.Clear();
            Console.WriteLine($"{colorPlayer} These are your cards: ");
            foreach(Card c in colorPlayer.hand){Console.WriteLine(c.value + " - " + c.name + " - " + c.desc);}

            Console.Write($"\n{colorPlayer} What card will you play (enter card number)? ");
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
            Console.WriteLine("\n===========================STATS=============================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red player has played the following cards: ");
            foreach(Card c in redPlayer.playedCards){Console.WriteLine(c.value + " - " + c.name);}
            Console.WriteLine("Red player rounds won (current game): " + this.redPlayer.roundsWon);
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nBlue player has played the following cards: ");
            foreach(Card c in bluePlayer.playedCards){Console.WriteLine(c.value + " - " + c.name);}
            Console.WriteLine("Blue player rounds won (current game): " + this.bluePlayer.roundsWon);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================================= \n");
            Console.Write("Press Any Key to continue: " );
            Console.ReadLine();
        }
        public void DisplayGameStats()
        {
            System.Console.WriteLine("\n===========================WINS=============================");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Red player game wins: " + this.redPlayer.gamesWon);
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Blue player game wins: " + this.bluePlayer.gamesWon);
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("============================================================= \n");
            Console.Write("Press Any Key to continue: ");
            Console.ReadLine();
        }
        public void CheckGameOver(Player colorPlayer,int result)
        {
            if(colorPlayer.roundsWon >= 4)
            {
                colorPlayer.gamesWon += 1;
                System.Console.WriteLine($"\n***** {colorPlayer} wins game! *****");
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
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\n***** Red player wins game! *****");
                Console.ForegroundColor = ConsoleColor.White;
                this.redPlayer.roundsWon = 0;
                this.DealNewGame();
            }
            else if(result == 4)
            {
                this.bluePlayer.gamesWon += 1;
                this.hold = 0;
                this.DisplayGameStats();
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("\n***** Blue player wins game! *****");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.Clear();
                Console.WriteLine("This round is on hold!");
                this.hold += 1;
                Console.WriteLine("Rounds on hold: " + this.hold);

                Console.Write("\nPress Any Key to continue: " );
                Console.ReadLine();
                this.PlayRound();
            }
            else if(result == 1)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nRed Player Wins round!");
                Console.ForegroundColor = ConsoleColor.White;
                this.redPlayer.roundsWon += 1 + this.hold;
                this.hold = 0;
                this.CheckGameOver(this.redPlayer,result);
            }
            else if(result == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("\nBlue Player Wins round!");
                Console.ForegroundColor = ConsoleColor.White;
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
