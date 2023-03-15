using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked.list
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Content { get; set; }
        public Node(T content)
        {
            Content = content;
        }
    }
    public class List<T>
    {
        private Node<T> First;
        public int NumberOfElements { get; set; }

        public void Add(T value)
        {
            Node<T> AdditionNode = new Node<T>(value);
            if (NumberOfElements == 0)
            {
                First = AdditionNode;
            }
            else
            {
                Node<T> PreviousNode = First;
                while (PreviousNode.Next != null)
                {
                    PreviousNode = PreviousNode.Next;
                }
                PreviousNode.Next = AdditionNode;
            }
            NumberOfElements++;
        }

        public void AddAt0(T value)
        {
            Node<T> AdditionNode = new Node<T>(value);
            if (NumberOfElements == 0)
            {
                First = AdditionNode;
            }
            else
            {
                    var auxNode = First;
                    AdditionNode.Next = auxNode;
                    First = AdditionNode;
            }
            NumberOfElements++;
        }

        public void Remove(T value)
        {
            Node<T> PriorNode = First;
            Node<T> FoundNode = First.Next;

            if (FoundNode == null)
            {
                PriorNode.Content = default(T);
                NumberOfElements--;
            }
            while (FoundNode != null)
            {
                if (PriorNode.Content.Equals(value))
                {
                    First = FoundNode;
                    NumberOfElements--;
                    break;
                }
                else if (FoundNode.Content.Equals(value))
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

        public T GetElement(int position)
        {
            Node<T> NodeToProcess = First;
            for (int i = 0; i < position; i++)
            {
                NodeToProcess = NodeToProcess.Next;
            }
            return NodeToProcess.Content;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                if (GetElement(i).Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < NumberOfElements; i++)
            {
                sb.Append("Position : ");
                sb.Append(i);
                sb.Append(" Content: ");
                sb.Append(GetElement(i));
                sb.Append(" // ");
            }

            return sb.ToString();
        }
    }
}