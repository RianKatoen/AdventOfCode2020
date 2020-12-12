using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Security.Passwords
{
    public class ValidPasswordCounter
    {
        private readonly IPasswordPolicyFactory _pwPolicyFactory;
        public ValidPasswordCounter(IPasswordPolicyFactory pwPolicyFactory)
        {
            _pwPolicyFactory = pwPolicyFactory;
        }

        /// <summary>
        /// Counts the number of valid passwords.
        /// </summary>
        /// <param name="passwords">List of passwords including their respective policies.</param>
        /// <param name="seperator">Seperator character for splitting policy and password.</param>
        /// <returns></returns>
        public int Count(IEnumerable<string> passwords, char seperator = ':')
        {
            var validCount = 0;
            foreach (var password in passwords)
            {
                var info = password.Split(seperator).ToArray();
                var policy = _pwPolicyFactory.Create(info[0].Trim());

                if (policy.Verify(info[1].Trim()))
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
