using System;
using System.Collections.Generic;

namespace DesignPatterns.Composite
{
    public class Program2
    {
        public static void Main2(string[] args)
        {
            int goldForKill = 1023;
            Console.WriteLine("You killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

            var joe = new Person { Name = "Joe" };
            var jake = new Person { Name = "Jake" };
            var emily = new Person { Name = "Emily" };
            var sophia = new Person { Name = "Sophia" };
            var brian = new Person { Name = "Brian" };
            
            // subgroup
            var oldBob = new Person { Name = "Old Bob" };
            var newBob = new Person { Name = "New Bob" };
            var bobs = new Group { Name = "Bobs", Members = { oldBob, newBob } };

            var developers = new Group { Name = "Developers", Members = { joe, jake, emily, bobs } };

            var parties = new List<IParty> { developers, sophia, brian };

            var totalToSplitBy = parties.Count;

            var amountForEach = goldForKill / totalToSplitBy;
            var leftOver = goldForKill % totalToSplitBy;

            foreach (var party in parties)
            {
                party.Gold += amountForEach + leftOver;
                leftOver = 0;
                party.Stats();
            }

            // we don't actually need to use a list, we can use a root group class 
            var root = new Group { Name = "Root", Members = { developers, sophia, brian } };
            root.Gold += goldForKill;
            root.Stats();
        }
    }
}
