namespace a3_cprg211_1.Utility
{
    using a3_cprg211_1.Problem_Domain;
    public class SLL : ILinkedListADT
    {
        public Node<User> Head { get; set; }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }

        public void AddLast(User value)
        {
            if (IsEmpty())
            {
                Head = new Node<User>(value);
            }
            else
            {
                Node<User> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<User>(value);
            }
        }

        public void AddFirst(User value)
        {
            Node<User> newNode = new Node<User>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void Add(User value, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
            }
            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node<User> current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    if (current == null)
                    {
                        throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                    }
                    current = current.Next;
                }

                if (current != null || (index == 1 && current == null))
                {
                    Node<User> newNode = new Node<User>(value);
                    if (current != null)
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                    }
                    else
                    {
                        Head = newNode;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                }
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is negative.");
            }

            if (Head == null)
            {
                throw new IndexOutOfRangeException("List is empty.");
            }

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == null)
                {
                    throw new IndexOutOfRangeException("Index is beyond the list size.");
                }
            }
            current.Value = value;
        }
        public int Count()
        {
            int count = 0;
            Node<User> current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException();
            }
            Head = Head.Next;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException();
            }
            if (Head.Next == null)
            {
                Head = null;
            }
            else
            {
                Node<User> current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node<User> current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    if (current == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    current = current.Next;
                }
                if (current == null || current.Next == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current.Next = current.Next.Next;
            }
        }

        public User GetValue(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current = current.Next;
            }
            if (current == null)
            {
                throw new IndexOutOfRangeException();
            }
            return current.Value;
        }

        public int IndexOf(User value)
        {
            Node<User> current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            Node<User> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public Node<User> ReverseLinkedList(Node<User> head)
        {
            Node<User> prev = null;
            Node<User> current = head;

            while (current != null)
            {
                Node<User> next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
    public class CannotRemoveException : Exception
    {
        public CannotRemoveException() : base() { }

        public CannotRemoveException(string message) : base(message) { }

    }
}
