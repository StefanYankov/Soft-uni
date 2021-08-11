using System.Collections.Generic;
using System.Linq;

namespace P03ThePianist
{
    using System;
    public class Program
    {
        public static void Main()
        {

            Dictionary<string, Piece> pieceRepository = new Dictionary<string, Piece>();

            int initialNumberOfPieces = int.Parse(Console.ReadLine());
            string input = string.Empty;
            for (int i = 1; i <= initialNumberOfPieces; i++)
            {
                input = Console.ReadLine();
                string[] inputArray = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = inputArray[0];
                string composer = inputArray[1];
                string key = inputArray[2];


                if (!pieceRepository.ContainsKey(piece))
                {
                    pieceRepository[piece] = new Piece(piece, composer, key);
                }
                else
                {
                    Console.WriteLine($"{piece} is already in the collection!");
                }
            }

            while (!(input = Console.ReadLine()).Equals("Stop"))
            {
                string[] commandArray = input.Split("|");
                string command = commandArray[0];
                string piece = commandArray[1];

                if (command.Equals("Add"))
                {
                    if (!pieceRepository.ContainsKey(piece))
                    {
                        string composer = commandArray[2];
                        string key = commandArray[3];
                        pieceRepository[piece] = new Piece(piece, composer, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command.Equals("Remove"))
                {
                    if (pieceRepository.ContainsKey(piece))
                    {
                        pieceRepository.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command.Equals("ChangeKey"))
                {
                    string newKey = commandArray[2];
                    if (pieceRepository.ContainsKey(piece))
                    {
                        pieceRepository[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieceRepository.OrderBy(x => x.Value.Name).ThenBy(x => x.Value.Composer))
            {
                Console.WriteLine($"{piece.Value.Name} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }

        }


    }

    public class Piece
    {
        public Piece()
        {
        }
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
