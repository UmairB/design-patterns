using DesignPatterns.Bridge.Formatter;

namespace DesignPatterns.Bridge.Document
{
    public abstract class Document
    {
        protected readonly IFormatter formatter;

        public Document(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public abstract void Print();
    }
}
