using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeJune.Task3
{
    public static class TwoCityScheduler
    {
        public static int TwoCitySchedCost(int[][] costs)
        {
            var result = 0;
            var orderedCosts = costs.OrderBy(x => x[0] - x[1]).ToArray();
            for (var i = 0; i < costs.Length; i++)
            {
                if (i < costs.Length / 2)
                    result += orderedCosts[i][0];
                else
                    result += orderedCosts[i][1];
            }
            return result;
        }
    }
}