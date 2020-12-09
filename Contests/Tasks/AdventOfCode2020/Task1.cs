using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Contests.Tasks.AdventOfCode2020
{
    public static class Task1
    {
        public static int? TryFindPairAnswer(int[] input)
        {
            var sorted = input.Where(x => x < 2020).OrderBy(x => x).ToArray();
            var pairIndices = TryFindPairIndices(sorted, 2020);
            return pairIndices == null
                ? (int?) null
                : sorted[pairIndices.Value.First] * sorted[pairIndices.Value.Second];
        }

        public static int? TryFindTripleAnswer(int[] input)
        {
            var sorted = input.Where(x => x < 2020).OrderBy(x => x).ToArray();
            foreach (var value in sorted)
            {
                var expectedRemainder = 2020 - value;
                var remainingIndices = TryFindPairIndices(sorted, expectedRemainder);
                if (remainingIndices != null)
                {
                    return value * sorted[remainingIndices.Value.First] * sorted[remainingIndices.Value.Second];
                }
            }

            return null;
        }

        private static (int First, int Second)? TryFindPairIndices(int[] sortedInput, int expectedSum)
        {
            for (var i = 0; i < sortedInput.Length - 1; i++)
            {
                var value = sortedInput[i];
                var pairValue = expectedSum - value;
                var pairIndex = Array.BinarySearch(sortedInput, i, sortedInput.Length - i, pairValue);
                if (pairIndex >= 0)
                {
                    return (i, pairIndex);
                }
            }

            return null;
        }
    }

    public class Task1Tests
    {
        [Test]
        public void TestExample()
        {
            var input = new[]
            {
                1721,
                979,
                366,
                299,
                675,
                1456
            };
            var expected = 514579;
            Task1.TryFindPairAnswer(input).Should().Be(expected);
        }

        [Test]
        public void TestSimple()
        {
            var input = new[]
            {
                1,
                2019
            };
            var expected = 2019;
            Task1.TryFindPairAnswer(input).Should().Be(expected);
        }

        [Test]
        public void TestMoreComplex()
        {
            var input = new[]
            {
                1,
                2019,
                1
            };
            var expected = 2019;
            Task1.TryFindPairAnswer(input).Should().Be(expected);
        }

        [Test]
        public void TestStupid()
        {
            var input = new[]
            {
                2020
            };
            Task1.TryFindPairAnswer(input).Should().Be(null);
        }

        [Test]
        public void TestMoreComplex2()
        {
            var input = new[]
            {
                500,
                2,
                7000777,
                12,
                1520,
                999,
                232
            };
            var expected = 500 * 1520;
            Task1.TryFindPairAnswer(input).Should().Be(expected);
        }

        [Test]
        public void TestFindTripleAnswerExample()
        {
            var input = new[]
            {
                1721,
                979,
                366,
                299,
                675,
                1456
            };
            var expected = 241861950;
            Task1.TryFindTripleAnswer(input).Should().Be(expected);
        }

        [Test]
        public void TestTask()
        {
            var input = new[]
            {
                1583, 1295, 1747, 1628, 1756, 1992, 1984, 1990, 2006, 1626, 1292, 1561, 1697, 1249, 2001, 1822, 1715,
                1951, 1600, 1615, 1769, 1825, 1335, 1987, 1745, 1660, 1952, 1437, 1348, 1968, 615, 1847, 476, 1346,
                1357, 1838, 1955, 1750, 1831, 2003, 1730, 1696, 1257, 1581, 866, 1765, 1691, 1995, 1977, 1988, 1713,
                1599, 1300, 1892, 1550, 2002, 1694, 1930, 1998, 1564, 1704, 1398, 864, 1480, 1578, 1946, 1850, 1964,
                1914, 1860, 1979, 1857, 1969, 1675, 1967, 2009, 1950, 1834, 783, 1935, 1963, 1659, 1314, 1647, 1671,
                1706, 1734, 1965, 1666, 316, 1657, 1663, 1373, 1719, 1778, 1559, 1869, 1958, 1986, 1845, 1643, 1783,
                1670, 1445, 1758, 2008, 1680, 1251, 1982, 1420, 1621, 1997, 1785, 1994, 1376, 1944, 1771, 1844, 96, 467,
                1954, 903, 1368, 1305, 1589, 1970, 1980, 1521, 1775, 1629, 1796, 1985, 1957, 1669, 1637, 1606, 1766,
                1972, 1956, 1685, 1235, 58, 1996, 1959, 1788, 1273, 1378, 1233, 1470, 1584, 1741, 1327, 1763, 1989,
                1665, 1667, 1975, 1862, 1791, 1229, 1873, 1761, 1754, 1882, 1642, 1971, 1777, 1580, 1648, 1678, 1266,
                1645, 502, 1717, 1723, 1244, 1370, 1898, 1755, 1708, 1983, 1901, 844, 1239, 1290, 1879, 1656, 1966,
                1929, 1993, 1743, 1909, 1451, 2000, 1978, 1938, 1707, 1337, 1362, 1263
            };
            Console.WriteLine(Task1.TryFindPairAnswer(input).Should());
            Console.WriteLine(Task1.TryFindTripleAnswer(input).Should());
        }
    }
}