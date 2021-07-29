namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this._head = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> toInsert = new Node<T>(item, this._head);
            this._head = toInsert;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>(item);
            Node<T> current = this._head;

            if (current == null)
            {
                this._head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toInsert;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.ValidateIfListIsNotEmpty();
            return this._head.Value;
        }

        public T GetLast()
        {
            this.ValidateIfListIsNotEmpty();
            Node<T> current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.ValidateIfListIsNotEmpty();
            Node<T> firstElement = this._head;
            this._head = this._head.Next;
            this.Count--;

            return firstElement.Value;
        }

        public T RemoveLast()
        {
            this.ValidateIfListIsNotEmpty();

            if (this._head.Next == null)
            {
                return this.RemoveFirst();

            }

            var current = this._head;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            var lastItem = current.Next.Value;
            current.Next = null;
            this.Count--;

            return lastItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIfListIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
        }
    }
}