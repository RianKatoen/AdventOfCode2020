using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Security.Passwords.NumberOfLetters
{
    public class NumberOfLettersPasswordPolicy : IPasswordPolicy
    {
        public readonly int MinTimes;
        public readonly int MaxTimes;
        public readonly char Character;
        public NumberOfLettersPasswordPolicy(int minTimes, int maxTimes, char character)
        {
            MinTimes = minTimes;
            MaxTimes = maxTimes;
            Character = character;
        }

        public NumberOfLettersPasswordPolicy(string policy)
        {
            var matches = Regex.Matches(policy, @"(\d+)-(\d+) ([a-z])", RegexOptions.Compiled);
            var captures = matches.First().Groups;

            MinTimes = int.Parse(captures[1].Value);
            MaxTimes = int.Parse(captures[2].Value);
            Character = captures[3].Value[0];
        }

        public bool Verify(string password)
        {
            var noCharacters = password
                .Where(letter => letter == Character)
                .Count();

            return MinTimes <= noCharacters && noCharacters <= MaxTimes;
        }
    }
}

