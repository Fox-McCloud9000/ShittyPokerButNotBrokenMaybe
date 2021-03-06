﻿using CardLibrary;
using static System.Console;
using System;
using System.Linq;

namespace DiazPokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyCards = 5;
            int balance = 10;

            ForegroundColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.DarkBlue;

            WriteLine("Welcome to simple poker! \nYou have $10 to start (this isn't Vegas) and each turn will be a $1 bet. (High roller aren't we?)");
            
            CardSet myDeck = new CardSet();

            do
            {
                myDeck.ResetUsage();
                
                WriteLine("Press the Enter key to bet $1");
                ReadKey();

                SuperCard[] computerHand = myDeck.GetCards(howManyCards); 

                SuperCard[] playersHand = myDeck.GetCards(howManyCards);

                Array.Sort(computerHand);

                Array.Sort(playersHand);

                DisplayHands(computerHand, playersHand);
                bool won = CompareHands(computerHand, playersHand);

                PlayerDrawsOne(howManyCards, myDeck, playersHand);
                ComputerDrawsOne(computerHand, myDeck);

                Array.Sort(computerHand);
                Array.Sort(playersHand);
                DisplayHands(computerHand, playersHand);
                
                if (CompareHands(computerHand,playersHand))
                {
                    balance++;
                    WriteLine("\nYou beat this really simple game by pure luck! Wow, good for you...(okay and maybe a tiny bit of skill)");
                    WriteLine($"You now have {balance:C}!");
                }
                else 
                {
                    balance--;
                    WriteLine("\nYou lost. Better get used to it.");
                    WriteLine("You have {0:C} left.", balance);
                }

                if (balance == 0)
                {
                    WriteLine("\nYou lost all of your money. Time to reflect on your life choices.");
                    won = false;
                }
            } while (balance != 0);
            
            Write("\nPress any key to exit>> ");
            ReadKey();
        }
        

        public static void DisplayHands(SuperCard[] passedInComputerHand, SuperCard[] passedInPlayersHand)
        {
            ResetColor();
            int compCardCount = 0;
            int playCardCount = 0;
            
            WriteLine("\nThis is the computer's hand."); 
            for (int i = 0; i < passedInComputerHand.Length; i++)
            {
                compCardCount++;
                Write($"{compCardCount}- ");
                passedInComputerHand[i].Display();
            }

            ResetColor();
            WriteLine("This is your hand");
            for (int i = 0; i < passedInPlayersHand.Length; i++)
            {
                playCardCount++;
                Write($"{playCardCount}- ");
                passedInPlayersHand[i].Display();
            }
           
            
        }
        
        private static bool CompareHands(SuperCard[] passedInComputerHand, SuperCard[] passedInPlayerHand)
        {
            if (Flush(passedInComputerHand)) 
            {
                WriteLine("\nComputer has a flush!\n");
                return false;
            }
            else if(Flush(passedInPlayerHand))
            {
                WriteLine("\nYou got a flush!\n");
                return true;
            }
                          
            else
            {
                int compScore = 0;
                int playerScore = 0;
                for (int i = 0; i < passedInComputerHand.Length; i++)
                {
                    compScore = compScore + (int)(passedInComputerHand[i].CardRank);
                }

                for (int i = 0; i < passedInPlayerHand.Length; i++)
                {
                    playerScore = playerScore + (int)(passedInPlayerHand[i].CardRank);
                }

                return playerScore > compScore;
            }
            
        }

        private static void PlayerDrawsOne(int pHowManyCards, CardSet pMyDeck, SuperCard[] pPlayerHand)
        {
            WriteLine("\nWhich card would you like to replace?");
            WriteLine($"Enter 1-{pHowManyCards}, or 0 if no cards: ");
            int a;
            int.TryParse(ReadLine(), out a);

            if (a > 0)
            {
                pPlayerHand[a - 1] = pMyDeck.GetOneCard();
            } 
        }

        private static void ComputerDrawsOne(SuperCard[] computerHand, CardSet myDeck)
        {
            SuperCard lowestCard = computerHand[0];

            if (Flush(computerHand))
            {

            }
            else
            {
                int a = 0;

                for (int i = 1; i < computerHand.Length; i++)
                {
                    if ((int)(computerHand[i].CardRank) < (int)(lowestCard.CardRank))
                    {
                        lowestCard = computerHand[i];
                        a = i;
                    }
                }

                if ((int)lowestCard.CardRank < 7)
                {
                    computerHand[a] = myDeck.GetOneCard();
                }
            }
        }

        private static bool Flush(SuperCard[] hand)
        {
            for (int i = 1; i < hand.Length; i++)
            {
                if (!hand[0].Equals(hand[i]))
                {
                    return false;
                }
            }return true;
        }
    }
}
