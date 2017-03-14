using DesignPatterns.Bridge.Formatter;
using System;

namespace DesignPatterns.Bridge.Document
{
    public class FAQ : Document
    {
        public FAQ(IFormatter formatter) : base(formatter)
        {
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
