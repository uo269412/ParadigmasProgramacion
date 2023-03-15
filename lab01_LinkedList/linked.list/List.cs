using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked.list
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
    public class List
    {
        private Node First;
        public int NumberOfElements { get; set; }

        public void Add(int number)
        {
            Node AdditionNode = new Node(number);
            if (NumberOfElements == 0)
            {
                First = AdditionNode;
            } else
            {
                Node PreviousNode = First;
                while (PreviousNode.Next != null )
                {
                    PreviousNode = PreviousNode.Next;
                }
                PreviousNode.Next = AdditionNode;
            }
            NumberOfElements++;
        }

        public void Remove(int value)
        {
            Node PriorNode = First;
            Node FoundNode = First.Next;

            while (FoundNode != null)
            {
                if (PriorNode.Content == value)
                {
                    First = FoundNode;
                    NumberOfElements--;
                    break;
                }
                else if (FoundNode.Content == value)
                {
                    PriorNode.Next = FoundNode.Next;
                    NumberOfElements--;
                    break;
                }
                else
                {
                    PriorNode = FoundNode;
                    FoundNode = FoundNode.Next;
                }
            }
        }

        public int GetElement(int position)
        {
            Node NodeToProcess = First;
            for (int i = 0; i < position; i++)
            {
                NodeToProcess = NodeToProcess.Next;
            }
            return NodeToProcess.Content;
        }
    }
}