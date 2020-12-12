using AdventOfCode2020.Security.Identification.ValidationRules;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Security.Identification
{
    public class PassportScanner
    {
        public IEnumerable<string> ParseData(string[] dataLines)
        {
            var record = "";
            foreach (var line in dataLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yield return record;
                    record = "";
                }
                else if (string.IsNullOrEmpty(record))
                {
                    record = line.Trim();
                }
                else
                {
                    record += $" {line.Trim()}";
                }
            }

            yield return record;
        }

        public Dictionary<string, string> GetFields(string data)
        {
            return data
                .Split(' ')
                .Select(f => f.Trim())
                .Select(f =>
                {
                    var kv = f.Split(':');
                    return KeyValuePair.Create(kv[0], kv[1]);
                })
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public bool ValidPassport(Dictionary<string, string> fields)
        {
            return fields.ContainsKey("byr")
                && fields.ContainsKey("iyr")
                && fields.ContainsKey("eyr")
                && fields.ContainsKey("hgt")
                && fields.ContainsKey("hcl")
                && fields.ContainsKey("ecl")
                && fields.ContainsKey("pid");
        }

        public bool ValidPassport(IEnumerable<IPassportValidationRule> rules, Dictionary<string, string> fields)
        {
            foreach (var rule in rules)
            {
                if (fields.TryGetValue(rule.PropertyName, out var value))
                {
                    if (!rule.Validate(value))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}