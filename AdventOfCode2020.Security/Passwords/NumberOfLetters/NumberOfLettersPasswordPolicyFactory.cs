using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Security.Passwords.NumberOfLetters
{
    public class NumberOfLettersPasswordPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy Create(string policy)
        {
            var matches = Regex.Matches(policy, @"(\d+)-(\d+) ([a-z])", RegexOptions.Compiled);
            var captures = matches.First().Groups;

            return new NumberOfLettersPasswordPolicy(
                minTimes: int.Parse(captures[1].Value),
                maxTimes: int.Parse(captures[2].Value),
                character: captures[3].Value[0]);
        }
    }
}

