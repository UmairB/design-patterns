using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Composite
{
    public class Group : IParty
    {
        public string Name { get; set; }

        public int Gold 
        { 
            get
            {
                return Members.Sum(m => m.Gold);
            }
            set
            {
                var eachSplit = value / Members.Count;
                var leftOver = value % Members.Count;

                foreach (var member in Members)
                {
                    member.Gold += eachSplit + leftOver;
                    leftOver = 0;
                }
            }
        }

        public List<IParty> Members { get; set; }

        public void Stats()
        {
            foreach (var member in Members)
            {
                member.Stats();
            }
        }
    }
}
