namespace P03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allCards = Console.ReadLine().Split(", ");

            List<Card> cardsList = new List<Card>();

            foreach (var cards in allCards)
            {
                string[] currentCard = cards.Split(" ");

                try
                {
                    string face = currentCard[0];
                    char suit = Convert.ToChar(currentCard[1]);

                    Card card = new Card(face, suit);
                    cardsList.Add(card);
                }
                catch (InvalidCardException ice)
                {
                    Console.WriteLine(ice.Message);
                }
                catch
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", cardsList));
        }
    }

    class Card
    {
        private string face;
        private char suit;

        public Card(string face, char suit)
        {
            Face = face;
            Suit = suit;
        }

        private string Face
        {
            get => face;

            set => face = FaceChecker(value);
        }

        private char Suit
        {
            get => suit;

            set => suit = SuitChecker(value);
        }

        private string FaceChecker(string value)
        {
            if (value == "10")
            {
                return value;
            }

            if (value.Length != 1) throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);

            if (char.IsDigit(Convert.ToChar(value)))
            {
                return value;
            }

            if (!char.IsLetter(Convert.ToChar(value)))
                throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
            switch (value)
            {
                case "J":
                case "Q":
                case "K":
                case "A":
                    return value;
                default:
                    throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
            }
        }

        private char SuitChecker(char value)
        {
            return value switch
            {
                'S' => '\u2660',
                'H' => '\u2665',
                'D' => '\u2666',
                'C' => '\u2663',
                _ => throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage)
            };
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }

    internal class InvalidCardException : Exception
    {
        public const string InvalidCardExceptionMessage = "Invalid card!";

        public InvalidCardException(string invalidCardExceptionMessage) : base(invalidCardExceptionMessage)
        {
        }
    }
}