using System;
using System.Collections.Generic;

namespace DesignPatterns.Adapter.Library
{
    public class DataAdapter : IDataAdapter
    {
        public void Fill(IDictionary<string, object> dataset)
        {
            if (dataset == null)
            {
                throw new ArgumentNullException(nameof(dataset));
            }
        }
    }
}
