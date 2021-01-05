using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Contests.Tasks.LeetCode
{
    public class FindRedundantDirectedConnectionTask
    {
        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            for (var i = edges.Length - 1; i >= 0; i--)
            {
                var patchedEdges = edges.ToList();
                patchedEdges.RemoveAt(i);
                if (IsValidGraph(patchedEdges.ToArray()))
                {
                    return edges[i];
                }
            }

            return new int[0];
        }

        private bool IsValidGraph(int[][] edges)
        {
            var nodes = new ConcurrentDictionary<int, DirectedNode>();
            foreach (var edge in edges)
            {
                var node1 = nodes.GetOrAdd(edge[0], new DirectedNode());
                var node2 = nodes.GetOrAdd(edge[1], new DirectedNode());

                node1.ChildNodes.Add(node2);
                if (node2.ParentNode != null)
                {
                    return false;
                }

                node2.ParentNode = node1;
            }

            var root = nodes.Values.SingleOrDefault(x => x.ParentNode == null); //todo: тут пропустил OrDefault
            if (root == null)
                return false;
            return nodes.Values.Any(x => HaveOnlyOnePathWithoutCycles(root, x)); //todo: тут ошибка?
        }

        private bool HaveOnlyOnePathWithoutCycles(DirectedNode start, DirectedNode finish)
        {
            if (start == finish)
            {
                return true;
            }

            var numberOfPaths = 0;
            var queue = new Queue<DirectedNode>(start.ChildNodes);
            var visitedNodes = new List<DirectedNode>();
            while (queue.Any())
            {
                var item = queue.Dequeue();
                if (visitedNodes.Contains(item))
                {
                    return false; //cycle
                }

                visitedNodes.Add(item);
                if (item == finish)
                {
                    numberOfPaths++;
                    continue;
                }

                foreach (var node in item.ChildNodes)
                {
                    queue.Enqueue(node);
                }
            }

            return numberOfPaths == 1;
        }

        private class DirectedNode
        {
            public readonly List<DirectedNode> ChildNodes = new List<DirectedNode>();
            public DirectedNode? ParentNode;
        }
    }
}