using DesignPatterns.Bridge.Formatter;
using System.Collections.Generic;

namespace DesignPatterns.Bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var documents = new List<Document.Document>();
            var formatter = new StandardFormatter();

            foreach (var doc in documents)
            {
                doc.Print();
            }
        }
    }
}
