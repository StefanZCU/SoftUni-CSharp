
using System.Runtime.CompilerServices;
using CollectionHierarchy.IO.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    using CollectionHierarchy.Models.Interfaces;
    using Interface;

    internal class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;

        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }

        private Engine()
        {
            addCollection = new AddCollection();
            addRemoveCollection = new AddRemoveCollection();
            myList = new MyList();
        }

        public void Run()
        {
            var input = _reader.ReadLine().Split();
            var removeOperationsCount = int.Parse(_reader.ReadLine());

            PrintResults(input, removeOperationsCount);
        }

        private void PrintResults(string[] input, int removeOperationsCount)
        {
            PrintAddedResults(input, addCollection);
            PrintAddedResults(input, addRemoveCollection);
            PrintAddedResults(input, myList);

            PrintRemovedResults(removeOperationsCount, addRemoveCollection);
            PrintRemovedResults(removeOperationsCount, myList);
        }

        private void PrintRemovedResults(int removeOperationsCount, IAddRemoveCollection collection)
        {
            var removedResults = new List<string>();

            for (int j = 0; j < removeOperationsCount; j++)
            {
                removedResults.Add(collection.Remove());
            }

            _writer.WriteLine(string.Join(" ", removedResults));
        }

        private void PrintAddedResults(string[] input, IAddCollection collection)
        {
            var addedResults = new List<int>();

            foreach (var text in input)
            {
                addedResults.Add(collection.Add(text));
            }

            _writer.WriteLine(string.Join(" ", addedResults));
        }
    }
}
