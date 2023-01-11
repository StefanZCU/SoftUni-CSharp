string input = Console.ReadLine();
Stack<char> reverseWord = new Stack<char>(input);
Console.WriteLine(String.Join("", reverseWord));

