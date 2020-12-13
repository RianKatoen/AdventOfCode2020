using AdventOfCode2020.Traveling.Luggage;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Luggage
{
    public class LuggageProcessorTests
    {
        private readonly string[] _input = File.ReadAllLines("Luggage/Example.txt");

        [Fact]
        public void AddRule_Should_Work_OneBag_Containing_TwoBags()
        {
            var sut = new LuggageProcessor();
            var bag = sut.AddRule("light red bags contain 1 bright white bag, 2 muted yellow bags.");

            Assert.Equal(3, sut.Bags.Count);
            Assert.True(sut.Bags.ContainsKey("light red"));
            Assert.True(sut.Bags.ContainsKey("bright white"));
            Assert.True(sut.Bags.ContainsKey("muted yellow"));

            var lightRedBag = sut.Bags["light red"];
            Assert.Equal("light red", lightRedBag.Type);
            Assert.Equal(2, lightRedBag.Bags.Count);

            Assert.Equal(1, lightRedBag.Bags["bright white"]);
            Assert.Equal(2, lightRedBag.Bags["muted yellow"]);
        }

        [Fact]
        public void AddRule_Should_Work_OneBag_Containing_OneBags()
        {
            var sut = new LuggageProcessor();
            var bag = sut.AddRule("light red bags contain 3 bright white bags.");

            Assert.Equal(2, sut.Bags.Count);
            Assert.True(sut.Bags.ContainsKey("light red"));
            Assert.True(sut.Bags.ContainsKey("bright white"));

            var lightRedBag = sut.Bags["light red"];
            Assert.Equal("light red", lightRedBag.Type);
            Assert.Single(lightRedBag.Bags);

            Assert.Equal(3, lightRedBag.Bags["bright white"]);
        }

        [Fact]
        public void AddRule_Should_Work_OneBag_Containing_NoBags()
        {
            var sut = new LuggageProcessor();
            var bag = sut.AddRule("dotted black bags contain no other bags.");

            var kvBag = Assert.Single(sut.Bags);
            Assert.Same(bag, kvBag.Value);

            Assert.Equal("dotted black", bag.Type);
            Assert.Equal("dotted black", kvBag.Key);
            Assert.Empty(bag.Bags);
        }

        [Fact]
        public void AddRule_Should_Work_MultipleBags()
        {
            var data = new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            var sut = new LuggageProcessor();
            foreach (var rule in data)
            {
                sut.AddRule(rule);
            }

            Assert.Equal(9, sut.Bags.Count);
        }

        [Fact]
        public void FindParentBags_Should_Work()
        {
            var data = new string[]
            {
                "awesome blue bags contain 2 light red bag, 2 dark orange bags.",
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            var sut = new LuggageProcessor();
            foreach (var rule in data)
            {
                sut.AddRule(rule);
            }

            Assert.Equal(10, sut.Bags.Count);

            // Depth n = 1
            {
                var parentBags = sut.FindParentBags("shiny gold", 1).ToList();
                Assert.Equal(2, parentBags.Count);
                Assert.Single(parentBags.Where(p => p.Type == "bright white"));
                Assert.Single(parentBags.Where(p => p.Type == "muted yellow"));
            }

            // Depth n = 2
            {
                var parentBags = sut.FindParentBags("shiny gold", 2).ToList();
                Assert.Equal(4, parentBags.Count);
                Assert.Single(parentBags.Where(p => p.Type == "bright white"));
                Assert.Single(parentBags.Where(p => p.Type == "muted yellow"));
                Assert.Single(parentBags.Where(p => p.Type == "light red"));
                Assert.Single(parentBags.Where(p => p.Type == "dark orange"));
            }
            // Depth n = null
            {
                var parentBags = sut.FindParentBags("shiny gold", 2).ToList();
                Assert.Equal(4, parentBags.Count);
                Assert.Single(parentBags.Where(p => p.Type == "bright white"));
                Assert.Single(parentBags.Where(p => p.Type == "muted yellow"));
                Assert.Single(parentBags.Where(p => p.Type == "light red"));
                Assert.Single(parentBags.Where(p => p.Type == "dark orange"));
            }
        }

        [Fact]
        public void CountTotalBags_Should_Work_TextExample()
        {
            var data = new string[]
            {
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags."
            };

            var sut = new LuggageProcessor();
            foreach (var rule in data)
            {
                sut.AddRule(rule);
            }

            Assert.Equal(5, sut.Bags.Count);

            Assert.Equal(7, sut.CountTotalBags("dark olive"));
            Assert.Equal(11, sut.CountTotalBags("vibrant plum"));
            Assert.Equal(32, sut.CountTotalBags("shiny gold"));
        }
    }
}
