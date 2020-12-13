using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Traveling.Luggage
{
    public class LuggageProcessor
    {
        public Dictionary<string, Bag> Bags { get; } = new Dictionary<string, Bag>();
        public Bag AddRule(string rule)
        {
            var bagStrings = rule.Split("contain");

            var bagName = Regex
                    .Match(bagStrings[0].Trim(), "([a-z]+ [a-z]+) bags", RegexOptions.Compiled)
                    .Groups[1]
                    .Value;

            if (!Bags.TryGetValue(bagName, out var bag))
            {
                bag = new Bag
                {
                    Type = bagName,
                    Bags = new Dictionary<string, int>()
                };

                Bags.Add(bagName, bag);
            }

            if (!bagStrings[1].Contains("no other bags"))
            {
                foreach (var bagString in bagStrings[1].Split(",").Select(b => b.Trim()))
                {
                    var regexContaingBag = Regex
                        .Match(bagString, "([0-9]+) ([a-z]+ [a-z]+) bag[s]?", RegexOptions.Compiled)
                        .Groups;

                    var numberOfContainingBags = int.Parse(regexContaingBag[1].Value);
                    if (!Bags.TryGetValue(regexContaingBag[2].Value, out var containingBag))
                    {
                        containingBag = new Bag
                        {
                            Type = regexContaingBag[2].Value,
                            Bags = new Dictionary<string, int>()
                        };

                        Bags.Add(containingBag.Type, containingBag);
                    }

                    bag.Bags.Add(containingBag.Type, numberOfContainingBags);
                }
            }

            return bag;
        }

        public IEnumerable<Bag> FindParentBags(string bagType, int? searchDepth = null)
        {
            var parentBags = new List<Bag>();
            foreach (var bag in Bags)
            {
                if (bag.Value.Bags.ContainsKey(bagType))
                {
                    parentBags.Add(bag.Value);
                }
            }

            var depth = 1;
            var searchBags = parentBags;
            while (searchBags.Count > 0 && depth < searchDepth.GetValueOrDefault(int.MaxValue))
            {
                // Store all the new bags in a list.
                var newSearchBags = new List<Bag>();
                foreach (var bag in searchBags)
                {
                    newSearchBags.AddRange(FindParentBags(bag.Type, 1));
                }
                // Distinct them.
                newSearchBags = newSearchBags
                    .Distinct()
                    .ToList();

                // Only search the bags which have not previously been searched already.
                searchBags = newSearchBags
                    .Where(b => !parentBags.Contains(b))
                    .ToList();

                // Add them to the total parent bags list.
                parentBags.AddRange(newSearchBags);
                parentBags = parentBags.Distinct().ToList();

                // Recalculate our looping status variable.
                depth++;
            }

            return parentBags;
        }

        public long CountTotalBags(string bagType)
        {
            long noOfBags = 0;
            foreach (var bag in Bags[bagType].Bags)
            {
                noOfBags += (1 + CountTotalBags(bag.Key)) * bag.Value;
            }

            return noOfBags;
        }
    }
}
