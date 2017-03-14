using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.Adapter.Library
{
    public class DataRenderer
    {
        private readonly IDataAdapter _dataAdapter;

        public DataRenderer(IDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public void Write(TextWriter writer)
        {
            var data = new Dictionary<string, object>();

            _dataAdapter.Fill(data);

            foreach (var kvp in data)
            {
                writer.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
