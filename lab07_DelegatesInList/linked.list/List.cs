using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace linked.list
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Content { get; set; }
        public Node(T content, Node<T> next)
        {
            Content = content;
            Next = next;
        }
    }

    internal class ListEnumerator<T> : IEnumerator<T>
    {
        private linked.list.List<T> list;
        private Node<T> currentNode;
        private int Index;

        public ListEnumerator(List<T> list)
        {
            Index = 0;
            this.list = list;
            Node<T> head = list.GetNode(0) as Node<T>;
            currentNode = new Node<T>(head.Content, head);
        }

        public T Current
        {
            get { return currentNode.Content; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Index >= list.Size)
            {
                return false;
            }
            else if (++Index < list.Size)
            {
                 currentNode.Content = list.GetElement(Index);
            }
            return true;
        }

        public void Reset()
        {
            Node<T> head = list.GetNode(0) as Node<T>;
            //The element of current node is set to the element of the head to avoid the creation of a new Node constructor,
            //it's not relevant at all
            currentNode = new Node<T>(head.Content, head);
        }
    }

    public class List<T> : IEnumerable<T>
    {
        private Node<T> Head;
        public int Size { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal Node<T> GetNode(int index)
        {
            int pos = 0;
            Node<T> node = this.Head;
            while (pos < index)
            {
                node = node.Next;
                pos++;
            }
            return node;
        }

        public void Add(T value)
        {
            Node<T> AdditionNode = new Node<T>(value, null);
            if (Size == 0)
            {
                Head = AdditionNode;
            }
            else
            {
                Node<T> PreviousNode = Head;
                while (PreviousNode.Next != null)
                {
                    PreviousNode = PreviousNode.Next;
                }
                PreviousNode.Next = AdditionNode;
            }
            Size++;
        }

        public void AddAt0(T value)
        {
            Node<T> AdditionNode = new Node<T>(value, null);
            if (Size == 0)
            {
                Head = AdditionNode;
            }
            else
            {
                var auxNode = Head;
                AdditionNode.Next = auxNode;
                Head = AdditionNode;
            }
            Size++;
        }

        public void Remove(T value)
        {
            Node<T> PriorNode = Head;
            Node<T> FoundNode = Head.Next;

            if (FoundNode == null)
            {
                PriorNode.Content = default(T);
                Size--;
            }
            while (FoundNode != null)
            {
                if (PriorNode.Content.Equals(value))
                {
                    Head = FoundNode;
                    Size--;
                    break;
                }
                else if (FoundNode.Content.Equals(value))
                {
                    PriorNode.Next = FoundNode.Next;
                    Size--;
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
            Node<T> NodeToProcess = Head;
            for (int i = 0; i < position; i++)
            {
                NodeToProcess = NodeToProcess.Next;
            }
            return NodeToProcess.Content;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Size; i++)
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
            for (int i = 0; i < Size; i++)
            {
                sb.Append("Position : ");
                sb.Append(i);
                sb.Append(" Content: ");
                sb.Append(GetElement(i));
                sb.Append(" // ");
            }

            return sb.ToString();
        }

        public IEnumerable<TResult> Map<TResult>(Func<T, TResult> function)
        {
            foreach (T element in this)
            {
                yield return function(element);
            }
            yield break;
        }

        public T Find(Predicate<T> function)
        {
            T result = default;
            foreach (var element in this)
            {
                if (function(element))
                {
                    result = element;
                    break;
                }
            }
            return result;
        }

        public IEnumerable<T> Filter(Predicate<T> function)
        {
            foreach (T element in this)
            {
                if (function(element))
                {
                    yield return element;
                }
            }
            yield break;
        }

        public T2 Reduce<T2>(T2 init, Func<T, T2, T2> function)
        {
            var result = init;
            foreach (T element in this)
            {
                result = function(element, result);
            }
            return result;
        }

        public void Invert()
        {
            Node<T> newHead = new Node<T>(GetNode(Size - 1).Content, new Node<T>(GetNode(Size-2).Content, null));
            for (int i = Size-2; i >= 0; i--)
            {
                Node<T> temp = newHead.Next;
                temp.Next = GetNode(i);
            }
            Head = newHead;
        }

        public void ForEach(Action<T> action)
        {
            foreach (T element in this)
            {
                action(element);
            }
        }


    }
}