using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace node
{
    public class Node
    {
        public Node Next { get; set; }
        public int Content { get; set; }
        public Node(int content)
        {
            Content = content;
        }
    }
}
