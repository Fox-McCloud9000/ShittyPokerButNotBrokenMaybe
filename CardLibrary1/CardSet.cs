using System;

namespace CardLibrary
{
    public class CardSet
    {
        
        const int NUM_OF_CARDS = 52;

        public Random rnd1 = new Random();

        public SuperCard[] cardArray;
       
        public CardSet()  // this is our constuctor, whose job it is to create all the 52 cards.
        {
            cardArray = new SuperCard[NUM_OF_CARDS];

            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                switch (s)
                {
                    case Suit.Club:
                        foreach (Rank v in Enum.GetValues(typeof(Rank)))
                        {
                            cardArray[i] = new CardClub(v);
                            i++;
                        }
                        break;
                    case Suit.Diamond:
                        foreach (Rank v in Enum.GetValues(typeof(Rank)))
                        {
                            cardArray[i] = new CardDiamond(v);
                            i++;
                        }
                        break;
                    case Suit.Heart:
                        foreach (Rank v in Enum.GetValues(typeof(Rank)))
                        {
                            cardArray[i] = new CardHeart(v);
                            i++;
                        }
                        break;
                    case Suit.Spade:
                        foreach (Rank v in Enum.GetValues(typeof(Rank)))
                        {
                            cardArray[i] = new CardSpade(v);
                            i++;
                        }
                        break;

                }
            }
        }
        
        
        public SuperCard[] GetCards(int passedNumer)
        {
            SuperCard[] handArray = new SuperCard[passedNumer];

            for (int i = 0; i < passedNumer; i++)
            {
                handArray[i] = GetOneCard();  
            }
            return handArray;

        }

        public void ResetUsage()
        {
            for (int i = 0; i < cardArray.Length; i++)
            {
                cardArray[i].inPlay = false;
            }
           
        }

        public SuperCard GetOneCard()
        {
            int rnd = rnd1.Next(0, 52);
            while (cardArray[rnd].inPlay)
            {
                rnd = rnd1.Next(0, 52);
            }
            cardArray[rnd].inPlay = true;
            return cardArray[rnd];
        }
    }
}