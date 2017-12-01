using System;
using static System.Console;
namespace CardLibrary
{
    //Card Suit and Rank enums.
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    //Supercard
    public abstract class SuperCard :  IComparable<SuperCard> , IEquatable<SuperCard>

    {
        public Rank CardRank { get; set; }

        public abstract Suit CardSuit { get; }

        public abstract void Display();

        public bool inPlay { get; set; }

        public int CompareTo(SuperCard other) //added sorting method
        {
            if (other == null) return 1;

            if(other.CardSuit < this.CardSuit)
            {
                return 1;
            }
            else if(other.CardSuit == this.CardSuit)
            {

                if (other.CardRank > this.CardRank)
                {
                    return 1;
                }

                if (other.CardRank < this.CardRank)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            return -1;
        }

        public bool Equals(SuperCard otherCard)
        {
            if(otherCard == null)
            {
                return false;
            }
            return (otherCard.CardSuit == this.CardSuit);
        }

    }

    //Child classes
    public class CardClub : SuperCard
    {
        private Suit _CardSuit = Suit.Club;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
           
        }

        public override void Display()
        {
            // Code to Display a club card...
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(CardRank + " of " + CardSuit + "s ♣");
            ResetColor();
        }

        public CardClub(Rank passedInRank) => CardRank = passedInRank;  // set this object's rank
    }

    public class CardDiamond : SuperCard
    {
        private Suit _CardSuit = Suit.Diamond;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine(CardRank + " of " + CardSuit + "s ♦");
            ResetColor();
        }
        
        public CardDiamond(Rank passedInRank) => CardRank = passedInRank;  // set this objets rank

    }

    public class CardHeart : SuperCard
    {
        private Suit _CardSuit = Suit.Heart;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
        }

        public override void Display()
        {
            // Code to Display a heart card...
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Red;
            WriteLine(CardRank + " of " + CardSuit + "s ♥");
            ResetColor();
        }
        
        public CardHeart(Rank passedInRank) => CardRank = passedInRank;  // set this objets rank
    }

    public class CardSpade : SuperCard
    {
        private Suit _CardSuit = Suit.Spade;
        public override Suit CardSuit
        {
            get
            {
                return _CardSuit;
            }
        }

        public override void Display()
        {
            // Code to Display a Spade card...
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            WriteLine(CardRank + " of " + CardSuit + "s ♠");
            ResetColor();
        }
 
        public CardSpade(Rank passedInRank) => CardRank = passedInRank;  // set this objets rank
    }   
}