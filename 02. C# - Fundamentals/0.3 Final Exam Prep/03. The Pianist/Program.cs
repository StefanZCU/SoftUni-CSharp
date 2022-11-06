using System;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    public class ComposerKey
    {
        public string Composer { get; set; }
        public string Key { get; set; }

        public ComposerKey(string composer, string key)
        {
            this.Composer = composer;
            this.Key = key;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numKeysInitial = int.Parse(Console.ReadLine());

            Dictionary<string, ComposerKey> composerKeyByPiece = new Dictionary<string, ComposerKey>();
            List<string> piecesToRemove = new List<string>();


            for (int i = 0; i < numKeysInitial; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                ComposerKey composerKey = new ComposerKey(input[1], input[2]);
                composerKeyByPiece.Add(input[0], composerKey);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] input = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Add")
                {
                    string piece = input[1];
                    string composer = input[2];
                    string key = input[3];

                    if (!composerKeyByPiece.ContainsKey(piece))
                    {
                        ComposerKey composerKey = new ComposerKey(composer, key);
                        composerKeyByPiece.Add(piece, composerKey);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (input[0] == "Remove")
                {
                    string piece = input[1];

                    if (composerKeyByPiece.ContainsKey(piece) && !piecesToRemove.Contains(piece))
                    {
                        piecesToRemove.Add(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (input[0] == "ChangeKey")
                {
                    string piece = input[1];
                    string key = input[2];

                    if (composerKeyByPiece.ContainsKey(piece))
                    {
                        composerKeyByPiece[piece].Key = key;
                        Console.WriteLine($"Changed the key of {piece} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in piecesToRemove)
            {
                composerKeyByPiece.Remove(piece);
            }

            foreach (var piece in composerKeyByPiece)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
