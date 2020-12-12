using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Expenses
{
    public class ReportGenerator
    {
        /// <summary>
        /// Algorithm for finding the sum of expenses in a given array.
        /// <b>IMPORTANT:</b> The array of expenses needs to be ordered ascending, otherwise the algorithm won't work.
        /// </summary>
        private (int Sum, int Product) InternalFindPair(int[] expenses, int target)
        {
            for (var i = 0; i < expenses.Length; i++)
            {
                var valueA = expenses[i];
                if (2 * valueA == target)
                    return (Sum: 2 * valueA, Product: valueA * valueA);
                if (2 * valueA > target)
                    break;

                for (var j = expenses.Length - 1; j >= 0; j--)
                {
                    var valueB = expenses[j];
                    var sum = valueA + valueB;

                    if (sum == target)
                        return (Sum: sum, Product: valueA * valueB);
                    else if (sum < target)
                        break;
                }
            }

            return (-1, -1);
        }

        public int FindPair(int[] expensesReport, int target)
        {
            var orderedExpenses = expensesReport
                .OrderBy(e => e)
                .ToArray();

            return InternalFindPair(orderedExpenses, target).Product;
        }

        public int FindTriplet(IEnumerable<int> expensesReport, int target)
        {
            var orderedExpenses = expensesReport
                .OrderBy(e => e)
                .ToArray();

            for (var i = 0; i < orderedExpenses.Length; i++)
            {
                var valueA = orderedExpenses[i];
                var (sum, product) = InternalFindPair(orderedExpenses, target - valueA);
                if (sum == -1 && product == -1)
                    continue;
                if (valueA + sum == target)
                    return valueA * product;
            }

            return -1;
        }
    }
}
