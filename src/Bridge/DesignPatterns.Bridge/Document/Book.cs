using DesignPatterns.Bridge.Formatter;
using System;

namespace DesignPatterns.Bridge.Document
{
    public class Book : Document
    {
        public Book(IFormatter formatter) : base(formatter)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
