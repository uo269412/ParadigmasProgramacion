using System;
using System.Text;
using System.Diagnostics;
using linked.list;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Stack {
        private linked.list.List<Object> linked;
        uint MaxNumberOfElements;

        public bool IsEmpty { get; set; }
        public bool IsFull { get; set; }


        public Stack(uint size)
        {
            linked = new linked.list.List<Object>();
            this.MaxNumberOfElements = size;
            IsEmpty = true;
        }

        public void Push(Object element)
        {
            try
            {
                CheckCondition(!IsFull, "We can't add an element when the stack is full");
                linked.AddAt0(element);
                IsEmpty = false;
                if (linked.NumberOfElements == MaxNumberOfElements)
                {
                    IsFull = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Debug.Assert(!IsEmpty, "The stack is empty when it can't be");
            try
            {
                CheckInvariant();
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public Object Pop()
        {
            try
            {
                CheckCondition(!IsEmpty, "We can't delete an element when the stack is empty");
                var RemovedElement = linked.GetElement(0);
                linked.Remove(RemovedElement);
                IsFull = false;
                if (linked.NumberOfElements == 0)
                {
                    IsEmpty = true;
                }
                return RemovedElement;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Debug.Assert(!IsFull, "The stack is full when it can't be");
            try
            {
                CheckInvariant();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(Object);
        }

        public static void Main() {
            Stack stack5 = new Stack(5);
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == true);
            stack5.Push("A");
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Push("B");
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Push("C");
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Push("D");
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Push("E");
            Debug.Assert(stack5.IsFull == true);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Push("E"); //Produces an error, shown on console

            stack5.Pop();
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Pop();
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Pop();
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Pop();
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == false);
            stack5.Pop();
            Debug.Assert(stack5.IsFull == false);
            Debug.Assert(stack5.IsEmpty == true);
            stack5.Pop(); //Produces an error, shown on console
        }

        private void CheckCondition(bool condition, string message)
        {
            if(!condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        //invariant: can't be empty and full at the same time assert

        private void CheckInvariant()
        {
            if ((IsEmpty == true &&  IsFull == true) || (linked.NumberOfElements > MaxNumberOfElements|| linked.NumberOfElements < 0) || (linked.Equals(null)))
            {
                throw new ArgumentException("Invariant can't succeed");
            }
        }
    }

}