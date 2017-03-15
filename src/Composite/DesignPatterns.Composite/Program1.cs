using System;
using System.Collections.Generic;

namespace DesignPatterns.Composite
{
    public class Program1
    {
        public static void Main1(string[] args)
        {
            int goldForKill = 1023;
            Console.WriteLine("You killed the Giant IE6 Monster and gained {0} gold!", goldForKill);

            var joe = new Person { Name = "Joe" };
            var jake = new Person { Name = "Jake" };
            var emily = new Person { Name = "Emily" };
            var sophia = new Person { Name = "Sophia" };
            var brian = new Person { Name = "Brian" };
            var developers = new Group { Name = "Developers", Members = { joe, jake, emily } };

            var individuals = new List<Person> { sophia, brian };
            var groups = new List<Group> { developers };

            var totalToSplitBy = individuals.Count + groups.Count;

            var amountForEach = goldForKill / totalToSplitBy;
            var leftOver = goldForKill % totalToSplitBy;

            foreach (var individual in individuals)
            {
                individual.Gold += amountForEach + leftOver;
                leftOver = 0;
                individual.Stats();
            }

            foreach (var group in groups)
            {
                var amountForEachGroupMember = amountForEach / group.Members.Count;
                var leftOverForGroup = amountForEach % group.Members.Count;

                foreach (var member in group.Members)
                {
                    member.Gold += amountForEachGroupMember + leftOverForGroup;
                    leftOverForGroup = 0;
                    member.Stats();
                }
            }
        }
    }
}
