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

        public string Face
        {
            get => face;

            private set => face = FaceChecker(value);
        }

        public char Suit
        {
            get => suit;

            private set => suit = SuitChecker(value);
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

            if (char.IsLetter(Convert.ToChar(value)))
            {
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

            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }

        private char SuitChecker(char value)
        {
            switch (value)
            {
                case 'S':
                    return '\u2660';
                case 'H':
                    return '\u2665';
                case 'D':
                    return '\u2666';
                case 'C':
                    return '\u2663';
                default:
                    throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }

    class InvalidCardException : Exception
    {
        public const string InvalidCardExceptionMessage = "Invalid card!";

        public InvalidCardException(string invalidCardExceptionMessage) : base(invalidCardExceptionMessage)
        {
        }
    }
}