using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LeetCodeJune.Task1;

namespace LeetCodeJune.Task2
{
    public static class ListNodeDeleter
    {
        public static void DeleteNode(ListNode node)
        {
            var temp = node.next;
            node.val = temp.val;
            node.next = temp.next;
        }
    }
}