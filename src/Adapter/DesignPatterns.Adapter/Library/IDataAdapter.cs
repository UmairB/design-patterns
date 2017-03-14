using System.Collections.Generic;

namespace DesignPatterns.Adapter.Library
{
    public interface IDataAdapter
    {
        void Fill(IDictionary<string, object> dataset);
    }
}